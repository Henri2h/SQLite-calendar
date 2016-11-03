using System.Text;
using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SQL_lite_database_search_wpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            new Core.AppCore(this);
            InitializeComponent();
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Core.AppCore.dCore.CloseDatabase();
        }
        public void showMessageBox(string content, string name)
        {
            MessageBoxButton btn = MessageBoxButton.OK;
            btn = MessageBoxButton.OK;
            ModernDialog.ShowMessage(content, name, btn);
        }
    }


}
