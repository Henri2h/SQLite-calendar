using System;
using System.Collections.Generic;
using System.Linq;
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

namespace SQL_lite_database_search_wpf.UI
{
    /// <summary>
    /// Interaction logic for DayUI.xaml
    /// </summary>
    public partial class DayUI : Grid
    {
        public DayUI(Day day)
        {
            InitializeComponent();
            tbDay.Text = day.name;
            tbDate.Text = day.Date.ToShortDateString();
        }
    }
}
