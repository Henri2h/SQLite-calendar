using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI
{
    /// <summary>
    /// Interaction logic for Controlls.xaml
    /// </summary>
    public partial class Controlls : UserControl
    {
        public delegate void UIEvent();
        public UIEvent RefreshISNeeded;

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
            Add_Project inputDialog = new Add_Project();
            inputDialog.Style = (Style)App.Current.Resources["BlankWindow"];

            inputDialog.ShowDialog();
            RefreshISNeeded?.Invoke();
        }
        private void btRefresch_Click(object sender, RoutedEventArgs e) { }
    }
}
