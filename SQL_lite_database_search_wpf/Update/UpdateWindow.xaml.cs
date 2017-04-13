using NAppUpdate.Framework;
using NAppUpdate.Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SQL_lite_database_search_wpf
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        private readonly UpdateManager _updateManager;
        private readonly UpdateTaskHelper _helper;
        private IList<UpdateTaskInfo> _updates;
        private int _downloadProgress;

        public UpdateWindow()
        {
            _updateManager = UpdateManager.Instance;
            _helper = new UpdateTaskHelper();
            InitializeComponent();

            var iconStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("NAppUpdate.Framework.updateicon.ico");
            if (iconStream != null)
                this.Icon = new IconBitmapDecoder(iconStream, BitmapCreateOptions.None, BitmapCacheOption.Default).Frames[0];
            this.DataContext = _helper;
        }

        private void InstallNow_Click(object sender, RoutedEventArgs e)
        {
            ShowThrobber();
            // dummy time delay for demonstration purposes
            var t = new System.Timers.Timer(2000) { AutoReset = false };
            t.Start();
            while (t.Enabled) { DoEvents(); }

            _updateManager.BeginPrepareUpdates(asyncResult =>
            {
                ((UpdateProcessAsyncResult)asyncResult).EndInvoke();

                // ApplyUpdates is a synchronous method by design. Make sure to save all user work before calling
                // it as it might restart your application
                // get out of the way so the console window isn't obstructed
                try
                {
                    _updateManager.ApplyUpdates(true);

                    if (Dispatcher.CheckAccess())
                    {
                        Close();
                    }
                    else
                    {
                        Dispatcher.Invoke(new Action(Close));
                    }
                }
                catch
                {
                    MessageBox.Show("An error occurred while trying to install software updates");
                }
                finally
                {
                    _updateManager.CleanUp();
                }
            }, null);
        }

        static void DoEvents()
        {
            var frame = new DispatcherFrame(true);
            Dispatcher.CurrentDispatcher.BeginInvoke
                (
                    DispatcherPriority.Background,
                    (System.Threading.SendOrPostCallback)delegate (object arg)
                    {
                        if (arg is DispatcherFrame f)
                        {
                            f.Continue = false;
                        }
                    },
                    frame
                );
            Dispatcher.PushFrame(frame);
        }

        private void ShowThrobber()
        {
            btnInstallAtExit.Visibility = Visibility.Collapsed;
            btnInstallNow.Visibility = Visibility.Collapsed;
            imgThrobber.Height = 30;
            imgThrobber.Visibility = Visibility.Visible;
            lblDownload.Visibility = Visibility.Visible;
        }

        private void InstallAtExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
