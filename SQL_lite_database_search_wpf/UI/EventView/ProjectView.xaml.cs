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
            LoadUsers();
        }

        public List<string> tableSourceHistory = new List<string>();
        public string tableSource { get; set; }

        public string DefaultUser = "All";
        public string CurrentUser = "All";


        /// <summary>
        /// Load all elements
        /// </summary>
        public void LoadElements()
        {
            LoadUsers();
            LoadElement(CurrentUser);
        }

        /// <summary>
        /// Load the element for a specific member
        /// </summary>
        /// <param name="seletction"></param>
        public void LoadElement(string selection)
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
                        if (selection == DefaultUser || selection == cObj.equipe.value) UIStackCalendarObjects.Items.Add(cObjView);
                    }
                }
                else
                {
                    TextBlock tb = new TextBlock()
                    {
                        Text = "No events"
                    };
                    UIStackCalendarObjects.Items.Add(tb);
                }
            }
        }

        void LoadUsers()
        {
            UIMemberSelection.Items.Clear();

            TextBlock all = AddUserMember(CurrentUser);
            UIMemberSelection.SelectedItem = all;

            if (CurrentUser != DefaultUser) AddUserMember(DefaultUser);

            foreach (string e in AppCore.Equipe)
            {
                if (e != CurrentUser) AddUserMember(e);
            }

        }

        TextBlock AddUserMember(string name)
        {
            TextBlock tb = new TextBlock()
            {
                Text = name
            };
            UIMemberSelection.Items.Add(tb);
            return tb;
        }

        public void AddNewElement()
        {
            UI.UIObjectManager.AddNewElement(tableSource);
            LoadElements();

        }

        private void CObjView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CalendarObjectView cView = (CalendarObjectView)sender;
            if (cView.CalendarObject.isRepository.value == true && cView.CalendarObject.projectTableName.value != null)
            {
                SetNewValue(cView.CalendarObject.projectTableName.value);
            }
            else
            { UI.UIObjectManager.ChangeCalendarObject(cView.CalendarObject); }

        }


        public void SetNewValue(string tableName)
        {
            tableSourceHistory.Add(tableSource);
            tableSource = tableName;
            LoadElements();
        }

        private void UIBtGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (tableSourceHistory.Count > 0)
            {
                tableSource = tableSourceHistory[tableSourceHistory.Count - 1];
                tableSourceHistory.RemoveAt(tableSourceHistory.Count - 1);
                LoadElements();
            }
        }

        private void UIMemberSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UIMemberSelection.SelectedItem != null)
            {
                TextBlock tb = (TextBlock)UIMemberSelection.SelectedItem;
                if (tb.Text == "" || tb.Text == null) tb.Text = DefaultUser;
                CurrentUser = tb.Text;
                LoadElement(CurrentUser);
            }
            else { LoadElement(DefaultUser); }
        }
    }
}
