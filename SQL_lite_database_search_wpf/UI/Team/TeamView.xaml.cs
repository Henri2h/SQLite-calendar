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
            loadTeam();
        }
        void loadTeam()
        {
            try
            {
                UIStackTeamElements.Children.Clear();
                List<EquipeMember> equipeMembers = Core.AppCore.dCore.EquipeMemberManager.getEquipeMembers();

                foreach (EquipeMember eMemb in equipeMembers)
                {
                    PersonView pView = new PersonView(eMemb);
                    pView.HorizontalAlignment = HorizontalAlignment.Left;
                    pView.VerticalAlignment = VerticalAlignment.Top;

                    UIStackTeamElements.Children.Add(pView);

                }
            }
            catch (Exception ex)
            {
                ex.Source = "SQL_lite_database_search_wpf.UI.Team.TeamView.loadTeam()";
                ErrorHandeler.ErrorMessage.logError(ex);


                UIStackTeamElements.Children.Clear();

                TextBlock tb = new TextBlock();
                tb.Text = "no team table";
                UIStackTeamElements.Background = new SolidColorBrush(Colors.Red);

                Button btAddTable = new Button();
                btAddTable.Content = "Create new  Team table";
                btAddTable.Click += AddTableClick;
                btAddTable.HorizontalAlignment = HorizontalAlignment.Left;


                UIStackTeamElements.Children.Add(tb);
                UIStackTeamElements.Children.Add(btAddTable);
            }
        }

        private void AddTableClick(object sender, RoutedEventArgs e)
        {
            Core.AppCore.dCore.EquipeMemberManager.createEquipeTable();
            loadTeam();
            UIStackTeamElements.Background = new SolidColorBrush(Colors.White);
        }

        private void UIBtAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow inputDialog = new AddUserWindow();
            inputDialog.Style = (Style)App.Current.Resources["BlankWindow"];
            inputDialog.ShowDialog();

            loadTeam();
        }
    }
}
