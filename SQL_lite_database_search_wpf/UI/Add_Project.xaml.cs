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
        objectMode mode;

        /// <summary>
        /// Create a new add project form
        /// </summary>

        public Add_Project(objectMode md)
        {
            mode = md;
            InitializeComponent();
            UIAddElement.Mode = mode;
        }
        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            mode = UIAddElement.Mode;
            if (mode == objectMode.project)
            {
                calendarObject prj = UIAddElement.getProject();
                AppCore.dCore.calendarObjectManager.addCalendarObject(prj);
            }
            else
            {
                calendarObject obj = UIAddElement.getCalendarObject();
                AppCore.dCore.calendarObjectManager.addCalendarObject(obj);
            }
            this.DialogResult = true;
        }
    }
}
