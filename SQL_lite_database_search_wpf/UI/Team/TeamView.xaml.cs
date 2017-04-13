using SQL_lite_database_search_wpf.Core.DatabaseItems;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            LoadTeam();
        }

        void LoadTeam()
        {
            try
            {
                UIStackTeamElements.Children.Clear();
                List<EquipeMember> equipeMembers = Core.AppCore.dCore.EquipeMemberManager.getEquipeMembers();

                foreach (EquipeMember eMemb in equipeMembers)
                {
                    PersonView pView = new PersonView(eMemb)
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top
                    };
                    UIStackTeamElements.Children.Add(pView);

                }
            }
            catch (Exception ex)
            {
                ex.Source = "SQL_lite_database_search_wpf.UI.Team.TeamView.loadTeam()";
                Usefull_Tools.ErrorHandeler.printOut(ex);


                UIStackTeamElements.Children.Clear();

                TextBlock tb = new TextBlock()
                {
                    Text = "no team table"
                };
                UIStackTeamElements.Background = new SolidColorBrush(Colors.Red);

                Button btAddTable = new Button()
                {
                    Content = "Create new  Team table"
                };
                btAddTable.Click += AddTableClick;
                btAddTable.HorizontalAlignment = HorizontalAlignment.Left;


                UIStackTeamElements.Children.Add(tb);
                UIStackTeamElements.Children.Add(btAddTable);
            }
        }

        private void AddTableClick(object sender, RoutedEventArgs e)
        {
            Core.AppCore.dCore.EquipeMemberManager.createEquipeTable();
            LoadTeam();
            UIStackTeamElements.Background = new SolidColorBrush(Colors.White);
        }

        private void UIBtAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow inputDialog = new AddUserWindow()
            {
                Style = (Style)App.Current.Resources["BlankWindow"]
            };
            inputDialog.ShowDialog();

            LoadTeam();
        }
    }
}
