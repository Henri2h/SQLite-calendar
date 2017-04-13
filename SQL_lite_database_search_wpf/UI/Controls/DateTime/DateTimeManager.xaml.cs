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
        public DateTime time_start { get { return dpTime_start.Value; } set { dpTime_start.Value = value; } }
        public DateTime time_end
        {
            get
            {
                if (isSeveralDays) return dpTime_end.Value;
                else return time_start;
            }
            set
            {
                dpTime_end.Value = value;
                isSeveralDays = true;
            }
        }

        public bool isHoursUsed { get { return IsHourUsed; } set { IsHourUsed = value; updateUI(); } }
        bool IsHourUsed = false;
        bool isSeveralDays = true;

        public DateTimeManager()
        {
            InitializeComponent();

            // default
            setValue(false);
        }

        private void ModernToggleButton_Click(object sender, RoutedEventArgs e) { setValue(UITbtIsDateUsed.IsChecked.Value); }

        void setValue(bool val)
        {
            if (val) { isDateUsed = true; }
            else { isDateUsed = false; }

            updateUI();
        }

        void updateUI()
        {
            UITbtIsDateUsed.IsChecked = isDateUsed;
            if (isDateUsed)
            {
                UIStackDate.Visibility = Visibility.Visible;
            }
            else
            {
                UIStackDate.Visibility = Visibility.Collapsed;
            }

            if (isSeveralDays)
            {
                dpTime_end.Visibility = Visibility.Visible;
            }
            else
            {
                dpTime_end.Visibility = Visibility.Collapsed;
            }


            dpTime_start.isHoursUsed = isHoursUsed;
            dpTime_end.isHoursUsed = IsHourUsed;
        }

        private void UITbtIsSeveralDay_Click(object sender, RoutedEventArgs e)
        {
            bool val = UITbtIsSeveralDay.IsChecked.Value;
            if (val) { isSeveralDays = true; }
            else { isSeveralDays = false; }

            updateUI();
        }
    }
}
