using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.UI.CalendarView.SpecificViews
{
    public class DayElement
    {
        public DayElement()
        {
            cobjs = new List<calendarObject>();
            cobjOneDay = new List<calendarObject>();
            cobjsDifferentDays = new List<calendarObject>();
        }

        public DateTime dateTime { get; set; }
        public string name { get; set; }
        public bool isSameMonth = false;
        public bool isTheSameDay = false;

        public List<calendarObject> cobjs { get; set; }

        public List<calendarObject> cobjOneDay { get; set; }
        public List<calendarObject> cobjsDifferentDays { get; set; }

    }
}
