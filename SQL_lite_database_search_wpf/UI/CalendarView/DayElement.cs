using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.UI.CalendarView.SpecificViews
{
    public class DayElement
    {
        public DateTime dateTime { get; set; }
        public string name { get; set; }
        public List<calendarObject> cobjs { get; set; }
    }
}
