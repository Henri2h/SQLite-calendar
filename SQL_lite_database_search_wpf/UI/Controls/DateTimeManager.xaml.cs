using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.Controls
{
    /// <summary>
    /// Interaction logic for DateTimeManager.xaml
    /// </summary>
    public partial class DateTimeManager : UserControl
    {
        public bool isDateUsed { get; set; }
        public DateTime time_start { get { return dpTime_start.Value; } }
        public DateTime time_end { get { return dpTime_end.Value; } }

        public DateTimeManager()
        {
            InitializeComponent();
        }
        private void ModernToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ModernToggleButton tgb = (ModernToggleButton)sender;
            if (tgb.IsChecked.Value)
            {
                UIStackDate.Visibility = Visibility.Visible;
                isDateUsed = true;
            }
            else
            {
                UIStackDate.Visibility = Visibility.Collapsed;
                isDateUsed = false;
            }

        }
    }
}
