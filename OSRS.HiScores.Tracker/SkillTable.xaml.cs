using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
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
    public class SkillColumn
    {
        public BitmapImage Icon { get; set; }

        public Skill Skill { get; set; }
    }
    
    public partial class SkillTable : UserControl
    {
        public ObservableCollection<SkillColumn> Columns { get; set; } = new();

        public SkillTable()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
