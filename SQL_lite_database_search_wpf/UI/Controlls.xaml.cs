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
    /// Interaction logic for Controlls.xaml
    /// </summary>
    public partial class Controlls : UserControl
    {
        public Controlls()
        {
            InitializeComponent();
        }
        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            //  loadElement();
        }
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder output = new StringBuilder();
            Add_window inputDialog = new Add_window();
            inputDialog.Style = (Style)App.Current.Resources["BlankWindow"];

            if (inputDialog.ShowDialog() == true)
            {
                calendarObject obj = inputDialog.Answer;
                Core.AppCore.SQLite.addCObjectInTable(obj);
            }
        }
        private void btRefresch_Click(object sender, RoutedEventArgs e) { }
    }
}
