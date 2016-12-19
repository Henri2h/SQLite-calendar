using FirstFloor.ModernUI.Windows.Controls;
using SQL_lite_database_search_wpf.Core;
using System.Windows;

namespace SQL_lite_database_search_wpf.UI
{
    /// <summary>
    /// Interaction logic for Add_Project.xaml
    /// </summary>
    public partial class Add_Project : ModernWindow
    {

        public Add_Project()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            calendarObject obj = UIAddElement.getCalendarObject();
            AppCore.dCore.calendarObjectManager.addCalendarObject(obj);
            this.DialogResult = true;
        }
    }
}
