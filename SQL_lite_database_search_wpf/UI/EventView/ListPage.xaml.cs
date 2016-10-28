using System.Windows;
using System.Windows.Controls;

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
