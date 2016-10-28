using System;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI
{
    public partial class DateTimePicker : UserControl
    {
        public DateTimePicker()
        {
            InitializeComponent();
            for (int i = 0; i < 25; i++) UIlsHours.Items.Add(i);
            for (int i = 0; i < 61; i++) UIlsMinutes.Items.Add(i);
        }
        public DateTime Value
        {
            get
            {
                try
                {
                    DateTime? sel = UICalPick.SelectedDate;
                    DateTime t = sel.Value.Date;
                    t.AddHours(UIlsHours.value);
                    t.AddMinutes(UIlsMinutes.value);
                    return t;
                }
                catch { return new DateTime(); }
            }
        }
    }
}
