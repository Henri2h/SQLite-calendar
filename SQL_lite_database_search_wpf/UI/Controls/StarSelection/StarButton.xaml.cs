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

namespace SQL_lite_database_search_wpf.UI.Controls.StarSelection
{
    /// <summary>
    /// Interaction logic for StarButton.xaml
    /// </summary>
    public partial class StarButton : Button
    {
        // this is for the UI
        public int StarPosition { get; set; }


        public bool enabled = false;
        public enum displayMode
        {
            switchMode,
            alwaysEnabledMode
        }
        public displayMode mode = displayMode.alwaysEnabledMode;

        public displayMode modeD { set { mode = value; } get { return mode; } }
        public StarButton()
        {
            InitializeComponent();
            updateUI();
        }

        public bool isStarEnabled
        {
            set
            {
                enabled = value;
                updateUI();
            }
            get { return enabled; }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mode == displayMode.switchMode) enabled = !enabled;

            updateUI();
        }


        void updateUI()
        {
            
            if (enabled == false) { UIImage.Source = new BitmapImage(new Uri("pack://application:,,,/UI/Controls/StarSelection/appbar.star.disabled.png")); }
            else { UIImage.Source = new BitmapImage(new Uri("pack://application:,,,/UI/Controls/StarSelection/appbar.star.png")); }
        }
    }
}
