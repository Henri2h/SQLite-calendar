using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core
{
    public class Project : calendarObject
    {
        // load default parameters for a project
        public Project()
        {
            isDateUsed.value = false;
        }


        public bool isAutomated = true;
        public List<calendarObject> events { get; set; }
        string projecttablename = "";

        public string projectTableName
        {
            get
            {
                if (isAutomated) { return name.value + "Events"; }
                else { return projecttablename; }
            }
            set
            {
                projecttablename = value;
                isAutomated = false;
            }
        }
        public List<calendarObject> listTheEventFromweek(DateTime seletedDay, DayOfWeek startWeek = DayOfWeek.Monday)
        {
            int start;
            switch (startWeek)
            {
                // 0
                case DayOfWeek.Sunday:
                    break;
                // 1
                case DayOfWeek.Monday:
                    start = 1;
                    break;
                // 2
                case DayOfWeek.Tuesday:
                    start = 2;
                    break;
                // 3
                case DayOfWeek.Wednesday:
                    start = 3;
                    break;
                // 4
                case DayOfWeek.Thursday:
                    start = 4;
                    break;
                // 5
                case DayOfWeek.Friday:
                    start = 5;
                    break;
                // 6
                case DayOfWeek.Saturday:
                    start = 6;
                    break;
            }
            // start ??
            DayOfWeek d = seletedDay.DayOfWeek;

            int pos = (int)seletedDay.DayOfWeek;
            int add = (int)d - pos;

            // start and en of week
            DateTime startofWeek = DateTime.Today.AddDays(add).Date;
            DateTime endOfWeek = DateTime.Today.AddDays(add + 7).Date;

            // calendar object list
            List<calendarObject> cObj = new List<calendarObject>();

            foreach (calendarObject c in events)
            {
                if (c.isDateUsed.value)
                {
                    if ((c.startTime.value >= startofWeek) && (endOfWeek >= c.endTime.value))
                    {
                        calendarObject cal = c;
                        DateTime s = startofWeek;
                        c.days = new DatabaseItems.DayManager();

                        for (int i = 0; i < 7; i++)
                        {

                        }
                        cObj.Add(cal);
                    }
                }
            }





            return cObj;
        }


        bool isDateIn(DateTime value, DateTime start, DateTime end)
        {

            if (value.Date >= start.Date)
            {
                if (end.Date >= value.Date)
                {
                    return true;
                }
            }

            return false;

        }
    }
}
