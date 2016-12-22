using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using System.IO;
using System;
using NAppUpdate.Framework;
using NAppUpdate.Framework.Common;
using System.ComponentModel;

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
                return "1.0.0.0";
            }
        }
        private bool applyUpdates;


        public MainWindow()
        {
            new Core.AppCore(this);
            InitializeComponent();

            MessageBox.Show(Files.getTempFile(".err"));
            MessageBox.Show(System.Environment.Version.ToString());
           
        }

      
        public void showMessageBox(string content, string name)
        {
            MessageBoxButton btn = MessageBoxButton.OK;
            btn = MessageBoxButton.OK;
            ModernDialog.ShowMessage(content, name, btn);
        }




        // updates


        private NAppUpdate.Framework.Sources.IUpdateSource PrepareUpdateSource()
        {
            // Normally this would be a web based source.
            // But for the demo app, we prepare an in-memory source.
            var source = new NAppUpdate.Framework.Sources.MemorySource(File.ReadAllText("AppUpdateFeed.xml"));
            source.AddTempFile(new Uri("http://carfam.freeboxos.fr/SQLiteAgenda/NewVersion.txt"), "NewVersion.txt");

            return source;
        }

        private void ModernWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var updManager = UpdateManager.Instance;
            updManager.UpdateSource = PrepareUpdateSource();
            updManager.ReinstateIfRestarted();
        }


        private void CheckForUpdates()
        {
            UpdateManager updManager = UpdateManager.Instance;

            updManager.BeginCheckForUpdates(asyncResult =>
            {
                Action showUpdateAction = ShowUpdateWindow;

                if (asyncResult.IsCompleted)
                {
                    // still need to check for caught exceptions if any and rethrow
                    ((UpdateProcessAsyncResult)asyncResult).EndInvoke();

                    // No updates were found, or an error has occured. We might want to check that...
                    if (updManager.UpdatesAvailable == 0)
                    {
                        MessageBox.Show("All is up to date!");
                        return;
                    }
                }

                applyUpdates = true;

                if (Dispatcher.CheckAccess())
                    showUpdateAction();
                else
                    Dispatcher.Invoke(showUpdateAction);
            }, null);
        }


        private void ShowUpdateWindow()
        {
            var updateWindow = new UpdateWindow();

            updateWindow.Closed += (sender, e) =>
            {
                if (UpdateManager.Instance.State == UpdateManager.UpdateProcessState.AppliedSuccessfully)
                {
                    applyUpdates = false;

                    // Update the app version
                    OnPropertyChanged("AppVersion");
                }
            };

            updateWindow.Show();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }

        private void ModernWindow_Closed(object sender, EventArgs e)
        {
            // Do any updates.
            if (applyUpdates)
            {
                try
                {
                    UpdateManager.Instance.PrepareUpdates();
                }
                catch
                {
                    UpdateManager.Instance.CleanUp();
                    return;
                }
                UpdateManager.Instance.ApplyUpdates(false);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
