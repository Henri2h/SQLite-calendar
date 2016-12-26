using FirstFloor.ModernUI.Windows.Controls;
using SQL_lite_database_search_wpf.Core;
using System;
using System.Windows;

namespace SQL_lite_database_search_wpf.UI
{
    /// <summary>
    /// Interaction logic for Add_Project.xaml
    /// </summary>
    public partial class Add_Project : ModernWindow
    {
        public string parentTable { get { return UICalendarInformation.ParentTable; } set { UICalendarInformation.ParentTable = value; } }

        public Add_Project()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                calendarObject obj = UICalendarInformation.CalendarObject;
                AppCore.dCore.calendarObjectManager.addCalendarObject(obj);
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                ex.Source = "SQL_lite_database_search_wpf.UI.Add_Project.btOk_Click";
                ErrorHandeler.ErrorMessage.logError(ex);
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
