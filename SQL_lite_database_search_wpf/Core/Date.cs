using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core
{
    public class Date
    {
        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }
            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }


        public static bool isDateBetween(calendarObject element, DateTime day)
        {
            if (element.isDateUsed.value == true)
            {
                double startDate = element.startTime.value.Date.ToOADate();
                double endDate = element.endTime.value.Date.ToOADate();

                double testDate = day.Date.Date.ToOADate();

                bool superior = (startDate <= testDate);
                bool inferior = (testDate <= endDate);

                if (superior && inferior) { return true; }
            }
            return false;
        }
        public static bool isDateBetween(calendarObject element, DateTime startDate, DateTime endDate)
        {
            if (element.isDateUsed.value == true)
            {
                bool superior = isOneOfSlectedDateBetween(element.startTime.value, startDate, endDate);
                bool inferior = isOneOfSlectedDateBetween(element.endTime.value, startDate, endDate);

                if (superior || inferior) { return true; }
            }
            return false;
        }


        public static bool isOneOfSlectedDateBetween(DateTime selectedDate, DateTime startDate, DateTime endDate)
        {

            if (startDate <= selectedDate || selectedDate <= endDate) { return true; }
            return false;
        }
    }
}
