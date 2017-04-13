using System.Collections.Generic;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.Controls
{
    /// <summary>
    /// Interaction logic for EquipeMemberSelection.xaml
    /// </summary>
    public partial class comboBoxSelection : UserControl
    {
        public string SelectedObjectName
        {
            get { return getSelectedObjectName(); }
            set
            {
                TextBlock tb = AddUserMember(value);
                UICBTeamMembers.SelectedItem = tb;
            }
        }

        List<string> elements = new List<string>();

        public string defaultValue = "All";
        public bool useDefaultValue = true;

        // events
        public delegate void CustomEventHandeler(string selectedObject);
        public event CustomEventHandeler SelectedObjectChanged;

        public comboBoxSelection()
        {
            InitializeComponent();
            LoadUsers(true);
        }

        public void AddObjectElement(string name)
        {
            elements.Add(name);
            LoadUsers();
        }

        public void LoadUsers(bool changeSelection = false)
        {
            UICBTeamMembers.Items.Clear();

            if (useDefaultValue)
            {
                TextBlock all = AddUserMember(defaultValue);
                if (changeSelection) UICBTeamMembers.SelectedItem = all;
            }

            foreach (string e in elements)
            {
                AddUserMember(e);
            }

        }

        TextBlock AddUserMember(string name)
        {
            TextBlock tb = new TextBlock()
            {
                Text = name
            };
            UICBTeamMembers.Items.Add(tb);
            return tb;
        }

        string getSelectedObjectName()
        {
            if (UICBTeamMembers.SelectedItem != null)
            {
                TextBlock tb = (TextBlock)UICBTeamMembers.SelectedItem;
                if (tb.Text == "" || tb.Text == null) tb.Text = defaultValue;
                return tb.Text;
            }
            else { return defaultValue; }

        }
        public void clearElements()
        {
            elements = new List<string>();
            LoadUsers();
        }


        private void UICBTeamMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedObjectChanged?.Invoke(getSelectedObjectName());
        }
    }
}
