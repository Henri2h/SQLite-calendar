using SQL_lite_database_search_wpf.Core.DatabaseItems;
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

namespace SQL_lite_database_search_wpf.UI.Team
{
    /// <summary>
    /// Interaction logic for TeamView.xaml
    /// </summary>
    public partial class TeamView : UserControl
    {
        public TeamView()
        {
            InitializeComponent();
        }
        void loadTeam()
        {
            UIStackTeamElements.Children.Clear();
            List<EquipeMember> equipeMembers = Core.AppCore.dCore.EquipeMemberManager.getEquipeMembers();

            foreach (EquipeMember eMemb in equipeMembers)
            {
                PersonView pView = new PersonView(eMemb);
                UIStackTeamElements.Children.Add(pView);

            }
        }

        private void UIBtAddUser_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
