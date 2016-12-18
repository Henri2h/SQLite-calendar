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
         
            // default
            setValue(false);
        }
        private void ModernToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ModernToggleButton tgb = (ModernToggleButton)sender;
            isDateUsed = tgb.IsChecked.Value;
            updateUI();
        }

        void setValue(bool val)
        {
            if (val) { isDateUsed = true; }
            else { isDateUsed = false; }

            UITbtIsDateUsed.IsChecked = isDateUsed;
            updateUI();
        }

        void updateUI()
        {
            if (isDateUsed)
            {
                UIStackDate.Visibility = Visibility.Visible;
            }
            else
            {
                UIStackDate.Visibility = Visibility.Collapsed;
            }
        }
    }
}
