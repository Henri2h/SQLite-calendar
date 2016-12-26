using System;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.Controls
{
    public partial class DateTimePicker : UserControl
    {

        public bool isHoursUsed { get { return IsHourUsed; } set { IsHourUsed = value; updateUI(); } }
        bool IsHourUsed = false;

        public DateTimePicker()
        {
            InitializeComponent();

            // populate the controll
            for (int i = 0; i < 25; i++) UIlsHours.Items.Add(i);
            for (int i = 0; i < 61; i++) UIlsMinutes.Items.Add(i);
        }

        void updateUI()
        {
            if (IsHourUsed) { UIStackHours.Visibility = System.Windows.Visibility.Visible; }
            else { UIStackHours.Visibility = System.Windows.Visibility.Collapsed; }
        }

        public DateTime Value
        {
            get
            {
                try
                {
                    DateTime? sel = UICalPick.SelectedDate;
                    DateTime t = sel.Value.Date;

                    if (IsHourUsed)
                    {
                        t.AddHours(UIlsHours.value - t.Hour);
                        t.AddMinutes(UIlsMinutes.value - t.Second);
                    }
                    return t;
                }
                catch { return new DateTime(); }
            }


            set
            {
                UICalPick.SelectedDate = value;
            }
        }
    }
}
