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

namespace SQL_lite_database_search_wpf.UI.DayView
{
    /// <summary>
    /// Logique d'interaction pour SmallCalendarView.xaml
    /// </summary>
    public partial class SmallCalendarView : UserControl
    {
        public SmallCalendarView(calendarObject cObj)
        {
            InitializeComponent();
            this.Background = new SolidColorBrush(cObj.color);
            this.UITbName.Text = cObj.name.value;

            if (cObj.description.value != "" && cObj.description.value != null)
            {
                this.ToolTip = cObj.description.value;
            }
        }
    }
}
