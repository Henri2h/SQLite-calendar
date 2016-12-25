using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.Settings
{
    /// <summary>
    /// Interaction logic for Apparence.xaml
    /// </summary>
    public partial class Apparence : UserControl
    {
        public Apparence()
        {
            InitializeComponent();
            // a simple view model for appearance configuration
            this.DataContext = new ApparenceManager();
        }
    }
}
