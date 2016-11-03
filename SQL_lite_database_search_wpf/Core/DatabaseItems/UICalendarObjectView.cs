using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseItems
{
    public class UICalendarObjectView
    {
        //      public int ID { get; set; }
        public string name { get; set; }

        public bool isDateUsed { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public string description { get; set; }
        public string domaine { get; set; }

        public int priorite { get; set; }
        public int completion { get; set; }
        public string equipe { get; set; }
        public string tableName { get; set; }
        public UICalendarObjectView(calendarObject c) { setValues(c); }
        public void setValues(calendarObject cObj)
        {
            this.name = cObj.name.value;
            this.description = cObj.description.value;
            this.equipe = cObj.equipe.value;
            this.domaine = cObj.domaine.value;

            this.priorite = cObj.priorite.value;
            this.completion = cObj.completion.value;

            this.isDateUsed = cObj.isDateUsed.value;
            this.startTime = cObj.startTime.value;
            this.endTime = cObj.endTime.value;
        }
    }
}
