using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Windows.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Net.Http;

namespace OSRS.HiScores.Tracker
{
    public partial class ScoreTable : UserControl, INotifyPropertyChanged
    {
        public ScoreTable()
        {
            InitializeComponent();
            this.DataContext = this;

            ModeSelector.Instance.ModeChanged += async (sender, mode) =>
            {
                this.CancelUpdateToken.Cancel();
                this.CancelUpdateToken = new CancellationTokenSource();
                await this.UpdateScores(this.CancelUpdateToken.Token);
            };
        }

        private static readonly DependencyProperty CategoryProperty
            = DependencyProperty.Register(
            "Category",
            typeof(Category),
            typeof(ScoreTable),
            new PropertyMetadata(Category.Overall)
        );

        private bool ScoresViewInitialized { get; set; } = false;

        private Dictionary<Mode, Dictionary<int, List<PlayerScores>>> CachedScores { get; set; } = new();

        private SemaphoreSlim UpdateLock { get; set; } = new(1, 1);

        private CancellationTokenSource CancelUpdateToken { get; set; } = new();

        public Category Category
        { 
            get
            {
                
                return (Category)GetValue(CategoryProperty);
            }
            set
            {
                SetValue(CategoryProperty, value);
            }
        }

        private int page = 1;

        public int Page 
        { 
            get
            {
                return page;
            }
            set
            {
                page = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<PlayerScores> Scores { get; init; } = new();

        public async Task UpdateScores(CancellationToken token)
        {
#if DEBUG
            DependencyObject dep = new DependencyObject();

            // Prevent XAML designer from spamming http requests lol...
            if (DesignerProperties.GetIsInDesignMode(dep))
                return;
#endif

            if (token.IsCancellationRequested || !this.IsVisible)
                return;

            await this.UpdateLock.WaitAsync();
            this.BusyIndicator.IsBusy = true;
            this.Scores.Clear();

            Mode currentMode = ModeSelector.Instance.CurrentMode;
            try
            {
                if (this.CachedScores.TryGetValue(currentMode, out var pages))
                {
                    if (pages.TryGetValue(this.Page, out var scores))
                    {
                        foreach (var p in scores)
                        {
                            if (token.IsCancellationRequested)
                                break;

                            this.Scores.Add(p);
                        }
                    }
                    else
                    {
                        List<PlayerScores> temp = new();
                        await foreach (var p in PlayerScores.GetAllAsync(this.Page, currentMode, this.Category))
                        {
                            if (token.IsCancellationRequested)
                                break;

                            temp.Add(p);
                            this.Scores.Add(p);
                        }

                        pages[this.Page] = temp;
                    }
                }
                else
                {
                    List<PlayerScores> temp = new();
                    await foreach (var p in PlayerScores.GetAllAsync(this.Page, currentMode, this.Category))
                    {
                        if (token.IsCancellationRequested)
                            break;

                        temp.Add(p);
                        this.Scores.Add(p);
                    }

                    this.CachedScores[currentMode] = new Dictionary<int, List<PlayerScores>> { { this.Page, temp } };
                }
            }
            catch(PlayerNotFoundException e)
            {
                // TODO:
            }
            catch (HttpRequestException e)
            {
                // TODO:
            }

            this.CancelUpdateToken = new CancellationTokenSource();
            this.BusyIndicator.IsBusy = false;
            this.UpdateLock.Release();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void ScoresViewLoaded(object sender, RoutedEventArgs e)
        {
            if(!ScoresViewInitialized)
            {
                GridView gridView = new GridView();
                GridViewColumn rankColumn = new GridViewColumn();
                rankColumn.DisplayMemberBinding = new Binding($"{this.Category}.Rank");
                rankColumn.Header = "Rank";
                rankColumn.Width = 120;
                gridView.Columns.Add(rankColumn);

                GridViewColumn nameColumn = new GridViewColumn();
                nameColumn.DisplayMemberBinding = new Binding("Name");
                nameColumn.Header = "Name";
                nameColumn.Width = 150;
                gridView.Columns.Add(nameColumn);

                GridViewColumn levelColumn = new GridViewColumn();
                levelColumn.DisplayMemberBinding = new Binding($"{this.Category}.Level");
                levelColumn.Header = "Level";
                levelColumn.Width = 150;
                gridView.Columns.Add(levelColumn);

                GridViewColumn xpColumn = new GridViewColumn();
                xpColumn.DisplayMemberBinding = new Binding($"{this.Category}.XP");
                xpColumn.Header = "XP";
                xpColumn.Width = 150;
                gridView.Columns.Add(xpColumn);

                this.ScoresView.View = gridView;
                this.ScoresViewInitialized = true;
            }

            this.CancelUpdateToken.Cancel();
            this.CancelUpdateToken = new CancellationTokenSource();

            await this.UpdateScores(this.CancelUpdateToken.Token);
        }

        private async void PageIncrement(object sender, RoutedEventArgs e)
        {
            this.CancelUpdateToken.Cancel();
            this.CancelUpdateToken = new CancellationTokenSource();
            this.Page++;
            await this.UpdateScores(this.CancelUpdateToken.Token);
        }

        private async void PageDecrement(object sender, RoutedEventArgs e)
        {
            if(this.Page > 1)
            {
                this.CancelUpdateToken.Cancel();
                this.CancelUpdateToken = new CancellationTokenSource();
                this.Page--;
                await this.UpdateScores(this.CancelUpdateToken.Token);
            }
        }
    }
}