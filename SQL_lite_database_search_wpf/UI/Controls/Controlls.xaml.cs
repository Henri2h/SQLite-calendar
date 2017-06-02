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
        public UIEvent AddNewElementAsked;

        public Controlls() { InitializeComponent(); }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            AddNewElementAsked?.Invoke();
        }
        private void BtRefresch_Click(object sender, RoutedEventArgs e)
        {
            RefreshISNeeded?.Invoke();
        }
    }
}
