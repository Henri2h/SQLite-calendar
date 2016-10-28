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

namespace SQL_lite_database_search_wpf.UI.EventView
{
    /// <summary>
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListPage : UserControl
    {
        bool isLoaded = false;
        public ListPage()
        {

            InitializeComponent();
            if (!isLoaded)
            {
                dataGrid.CanUserAddRows = true;
                loadElement();
            }
            isLoaded = true;
        }
        private void loadElement()
        {
            dataGrid.ItemsSource = Core.AppCore.SQLite.cElements;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                dataGrid.CanUserAddRows = true;
                loadElement();
            }
            isLoaded = true;
        }
    }
}
