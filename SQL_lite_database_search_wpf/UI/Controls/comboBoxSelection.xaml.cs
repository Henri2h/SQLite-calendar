using System.Collections.Generic;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.Controls
{
    /// <summary>
    /// Interaction logic for EquipeMemberSelection.xaml
    /// </summary>
    public partial class comboBoxSelection : UserControl
    {
        public string selectedObjectName
        {
            get { return getSelectedObjectName(); }
            set
            {
                TextBlock tb = addUserMember(value);
                UICBTeamMembers.SelectedItem = tb;
            }
        }

        List<string> elements = new List<string>();
        public string defaultValue = "All";

        // events
        public delegate void CustomEventHandeler(string selectedObject);
        public event CustomEventHandeler selectedObjectChanged;

        public comboBoxSelection()
        {
            InitializeComponent();
            loadUsers(true);
        }

        public void AddObjectElement(string name)
        {
            elements.Add(name);
            loadUsers();
        }

        public void loadUsers(bool changeSelection = false)
        {
            UICBTeamMembers.Items.Clear();

            TextBlock all = addUserMember(defaultValue);
            if (changeSelection) UICBTeamMembers.SelectedItem = all;

            foreach (string e in elements)
            {
                addUserMember(e);
            }

        }

        TextBlock addUserMember(string name)
        {
            TextBlock tb = new TextBlock();
            tb.Text = name;
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
            loadUsers();
        }
       

        private void UICBTeamMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedObjectChanged?.Invoke(getSelectedObjectName());
        }
    }
}
