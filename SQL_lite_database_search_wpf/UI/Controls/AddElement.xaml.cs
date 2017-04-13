using SQL_lite_database_search_wpf.Core;
using System;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.Controls
{
    /// <summary>
    /// Interaction logic for AddElement.xaml
    /// </summary>
    public partial class AddElement : UserControl
    {
        public AddElement()
        {
            InitializeComponent();
        }

        public calendarObject getCalendarObject() { return UICalendarInformations.CalendarObject; }
        private void UIBtRefresh_Click(object sender, System.Windows.RoutedEventArgs e) { UICalendarInformations.LoadMenuItems(); }


    }
}
