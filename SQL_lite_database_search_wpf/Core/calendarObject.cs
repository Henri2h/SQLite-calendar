using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf
{
    public class calendarObject
    {
        public int ID { get; set; }
        public string name { get; set; }

        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public string description { get; set; }
        public string domaine { get; set; }

        public int priorite { get; set; }
        public int completion { get; set; }
        public string equipe { get; set; }

    }
}