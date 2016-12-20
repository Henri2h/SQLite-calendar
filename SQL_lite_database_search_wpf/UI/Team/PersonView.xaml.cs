using SQL_lite_database_search_wpf.Core.DatabaseItems;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.Team
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        public PersonView(EquipeMember eMemb)
        {
            InitializeComponent();
            UITbName.Text = eMemb.name.value;

        }
    }
}
