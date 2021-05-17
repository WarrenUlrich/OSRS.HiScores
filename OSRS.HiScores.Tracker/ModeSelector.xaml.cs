using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OSRS.HiScores.Tracker
{
    /// <summary>
    /// Interaction logic for ModeSelector.xaml
    /// </summary>
    public partial class ModeSelector : UserControl
    {
        public ModeSelector()
        {
            InitializeComponent();
            this.ModeSelection.SelectedIndex = 0;
            Instance = this;

        }

        public static ModeSelector Instance { get; private set; }

        public event EventHandler<Mode> ModeChanged;

        public Mode CurrentMode
        {
            get
            {
                return (Mode)this.ModeSelection.SelectedIndex;
            }
            set
            {
                this.ModeSelection.SelectedIndex = (int)value;
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ModeChanged?.Invoke(this, this.CurrentMode);
        }
    }
}
