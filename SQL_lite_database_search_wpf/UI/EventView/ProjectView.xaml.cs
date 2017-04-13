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
        /// <summary>
        /// Project view page creation and load the users
        /// </summary>
        public ProjectView()
        {
            InitializeComponent();
            loadUsers(true);
        }

        public List<string> tableSourceHistory = new List<string>();
        public string tableSource { get; set; }

        /// <summary>
        /// Load all elements
        /// </summary>
        public void loadElement()
        {
            loadElement("All");
            loadUsers();
        }

        /// <summary>
        /// Load the element for a specific member
        /// </summary>
        /// <param name="seletction"></param>
        public void loadElement(string seletction)
        {
            if (tableSource != null)
            {
                UIStackCalendarObjects.Items.Clear();

                List<calendarObject> cObjs = AppCore.dCore.CalendarObjectManager.ListCalendarObjects(tableSource);
                if (cObjs.ToArray().Length != 0)
                {
                    foreach (calendarObject cObj in cObjs)
                    {
                        CalendarObjectView cObjView = new CalendarObjectView(cObj);
                        cObjView.MouseDoubleClick += CObjView_MouseDoubleClick;
                        if (seletction == "All" || seletction == cObj.equipe.value) UIStackCalendarObjects.Items.Add(cObjView);
                    }
                }
                else
                {
                    TextBlock tb = new TextBlock();
                    tb.Text = "No events";
                    UIStackCalendarObjects.Items.Add(tb);
                }
            }
        }

        void loadUsers(bool changeSelection = false)
        {
            UIMemberSelection.Items.Clear();

            TextBlock all = addUserMember("All");
            if (changeSelection) UIMemberSelection.SelectedItem = all;

            foreach (string e in AppCore.Equipe)
            {
                addUserMember(e);
            }

        }
        TextBlock addUserMember(string name)
        {
            TextBlock tb = new TextBlock();
            tb.Text = name;
            UIMemberSelection.Items.Add(tb);
            return tb;
        }

        public void addNewElement()
        {
            UI.UIObjectManager.AddNewElement(tableSource);
            loadElement();
        }

        private void CObjView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CalendarObjectView cView = (CalendarObjectView)sender;
            if (cView.CalendarObject.isRepository.value == true && cView.CalendarObject.projectTableName.value != null)
            {
                setNewValue(cView.CalendarObject.projectTableName.value);
            }
            else MessageBox.Show("Not a repository");
        }


        public void setNewValue(string tableName)
        {
            tableSourceHistory.Add(tableSource);
            tableSource = tableName;
            loadElement();
        }

        private void UIBtGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (tableSourceHistory.Count > 0)
            {
                tableSource = tableSourceHistory[tableSourceHistory.Count - 1];
                tableSourceHistory.RemoveAt(tableSourceHistory.Count - 1);
                loadElement();
            }
        }

        private void UIMemberSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UIMemberSelection.SelectedItem != null)
            {
                TextBlock tb = (TextBlock)UIMemberSelection.SelectedItem;
                if (tb.Text == "" || tb.Text == null) tb.Text = "All";
                loadElement(tb.Text);
            }
            else { loadElement("All"); }
        }
    }
}
