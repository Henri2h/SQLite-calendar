using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.UI.CalendarView.SpecificViews
{
    public class CalendarContent

    {
        public CalendarContent()
        {
            dayNames = new List<string>();
            content = new List<DayElement>();
            specificDay = new List<DayElement>();
        }

        public List<string> dayNames { get; set; }
        public List<DayElement> content { get; set; }
        public List<DayElement> specificDay { get; set; }
    }
}
