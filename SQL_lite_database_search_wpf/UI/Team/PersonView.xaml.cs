using SQL_lite_database_search_wpf.Core.DatabaseItems;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.Team
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        EquipeMember equipeMember { get; set; }
        public PersonView(EquipeMember eMemb)
        {
            InitializeComponent();
            equipeMember = eMemb;
            loadElement();
        }

        void loadElement()
        {
            UITbName.Text = equipeMember.name.value;
        }

        private void UIBtDeleteUser_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                Core.AppCore.dCore.EquipeMemberManager.deleteEquipeMember(equipeMember);
                this.Visibility = System.Windows.Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                ex.Source = " SQL_lite_database_search_wpf.UI.Team.PersonView.UIBtDeleteUser_Click";
                ErrorHandeler.ErrorMessage.logError(ex);
                MessageBox.Show("Could not delete the user");
            }


        }
    }
}
