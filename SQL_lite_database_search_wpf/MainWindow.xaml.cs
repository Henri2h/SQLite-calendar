using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using System.IO;
using System;
using System.ComponentModel;
using Microsoft.HockeyApp;

namespace SQL_lite_database_search_wpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {

        public string AppVersion
        {
            get
            {
                if (File.Exists("CurrentVersion.txt"))
                    return File.ReadAllText("CurrentVersion.txt");
                return "1.0.1.0";
            }
        }

        public MainWindow()
        {
            LaunchHockeyReportingAsync();
            Usefull_Tools.Logger.AppName = "SQLite_Agenda";
            Usefull_Tools.Logger.logMain("Starting ...");

            new Core.AppCore(this);
            InitializeComponent();
        }

        public async void LaunchHockeyReportingAsync()
        {
            HockeyClient.Current.Configure("478c98e3be7049778423ff194e5c50d1");
            await HockeyClient.Current.SendCrashesAsync();
        }


        public void ShowMessageBox(string content, string name)
        {
            MessageBoxButton btn = MessageBoxButton.OK;
            btn = MessageBoxButton.OK;
            ModernDialog.ShowMessage(content, name, btn);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Usefull_Tools.Logger.logMain("Stopping ..." + Environment.NewLine);
        }
    }
}
