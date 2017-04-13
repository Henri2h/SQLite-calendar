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

namespace SQL_lite_database_search_wpf.UI.Settings
{
    /// <summary>
    /// Interaction logic for Database.xaml
    /// </summary>
    public partial class Database : UserControl
    {
        public Database()
        {
            InitializeComponent();
            UITbDPath.Text = Core.AppCore.DatabasePath;
        }



        private void UIBtChangeDatabase_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented");
        }
    }
}
