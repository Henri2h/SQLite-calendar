using SQL_lite_database_search_wpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQL_lite_database_search_wpf.UI.Controls
{
    /// <summary>
    /// Interaction logic for EquipeMemberSelection.xaml
    /// </summary>
    public partial class EquipeMemberSelection : UserControl
    {
        public string selectedMemberName
        {
            get { return getSelectedMemberName(); }
            set
            {
                TextBlock tb = addUserMember(value);
                UICBTeamMembers.SelectedItem = tb;
            }
        }

        // events
        public delegate void CustomEventHandeler(string selectedMemberName);
        public event CustomEventHandeler selectedMemberNameChanged;

        public EquipeMemberSelection()
        {
            InitializeComponent();
            loadUsers(true);
        }

        void loadUsers(bool changeSelection = false)
        {
            UICBTeamMembers.Items.Clear();

            TextBlock all = addUserMember("All");
            if (changeSelection) UICBTeamMembers.SelectedItem = all;

            foreach (string e in AppCore.Equipe)
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

        string getSelectedMemberName()
        {
            if (UICBTeamMembers.SelectedItem != null)
            {
                TextBlock tb = (TextBlock)UICBTeamMembers.SelectedItem;
                if (tb.Text == "" || tb.Text == null) tb.Text = "All";
                return tb.Text;
            }
            else { return "All"; }

        }

        private void UIMemberSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMemberNameChanged?.Invoke(getSelectedMemberName());
        }
    }
}
