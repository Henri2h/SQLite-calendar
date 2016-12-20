using SQL_lite_database_search_wpf.Core.DatabaseItems;
using System.Windows;

namespace SQL_lite_database_search_wpf.UI.Team
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void UIBtOK_Click(object sender, RoutedEventArgs e)
        {
            EquipeMember eMember = new EquipeMember();
            eMember.name.value = UITbUserName.Text;
            Core.AppCore.dCore.EquipeMemberManager.addMember(eMember);
        }
    }
}
