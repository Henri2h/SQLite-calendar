using SQL_lite_database_search_wpf.Core;
using SQL_lite_database_search_wpf.Core.DatabaseItems;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.EventView
{
    /// <summary>
    /// Interaction logic for ProjectView.xaml
    /// </summary>
    public partial class ProjectView : UserControl
    {
        public ProjectView()
        {
            InitializeComponent();

        }
        public List<string> tableSourceHistory = new List<string>();
        public string tableSource { get; set; }

        public void loadElement()
        {

            UIStackCalendarObjects.Children.Clear();



            List<calendarObject> cObjs = AppCore.dCore.calendarObjectManager.listCalendarObjects(tableSource);
            if (cObjs.ToArray().Length != 0)
            {

                foreach (calendarObject cObj in cObjs)
                {
                    CalendarObjectView cObjView = new CalendarObjectView(cObj);
                    cObjView.MouseDoubleClick += CObjView_MouseDoubleClick;
                    UIStackCalendarObjects.Children.Add(cObjView);




                }
            }
            else { TextBlock tb = new TextBlock(); tb.Text = "No events"; UIStackCalendarObjects.Children.Add(tb); }
        }

        private void CObjView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CalendarObjectView cView = (CalendarObjectView)sender;
            if (cView.CalendarObject.isRepository.value == true && cView.CalendarObject.projectTableName.value != null)
            {

                setNewValue(cView.CalendarObject.projectTableName.value);
            }
            else MessageBox.Show("Not repository");
        }


        public void setNewValue(string tableName)
        {
            tableSourceHistory.Add(tableSource);
            tableSource = tableName;
            loadElement();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.CanUserAddRows = true;
        }
    }
}
