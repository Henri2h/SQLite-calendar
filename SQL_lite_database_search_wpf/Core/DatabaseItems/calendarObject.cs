using SQL_lite_database_search_wpf.Core.DatabaseItems;
using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;
using SQL_lite_database_search_wpf.Core.DatabaseManager;
using System;
using System.Collections.Generic;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SQL_lite_database_search_wpf
{
    /// <summary>
    /// base class of the calendar object
    /// </summary>
    public class calendarObject
    {

        // ==============  data values ==============
        public sqliteBase[] values = new sqliteBase[12];


        // data access:
        //=============

        // definitions
        public sqliteString name { get { return (sqliteString)values[0]; } set { values[0] = value; } }
        public sqliteInt elementID { get { return (sqliteInt)values[1]; } set { values[1] = value; } }


        // date
        public sqliteBool isDateUsed { get { return (sqliteBool)values[2]; } set { values[2] = value; } }
        public sqliteDateTime startTime { get { return (sqliteDateTime)values[3]; } set { values[3] = value; } }
        public sqliteDateTime endTime { get { return (sqliteDateTime)values[4]; } set { values[4] = value; } }

        public sqliteString description { get { return (sqliteString)values[5]; } set { values[5] = value; } }
        public sqliteString domaine { get { return (sqliteString)values[6]; } set { values[6] = value; } }

        public sqliteInt priorite { get { return (sqliteInt)values[7]; } set { values[7] = value; } }
        public sqliteInt completion { get { return (sqliteInt)values[8]; } set { values[8] = value; } }
        public sqliteString equipe { get { return (sqliteString)values[9]; } set { values[9] = value; } }

        // table and repository
        public sqliteBool isRepository { get { return (sqliteBool)values[10]; } set { values[10] = value; } }
        public sqliteString projectTableName { get { return (sqliteString)values[11]; } set { values[11] = value; } }

        // color
        public sqliteColor color { get { return (sqliteColor)values[12]; } set { values[12] = value; } }


        public calendarObject() { createCalendarObject(); }
        public calendarObject(string name)
        {
            createCalendarObject();
            this.name.value = name;
        }

        void createCalendarObject()
        {
            values[0] = new sqliteString("name");
            values[1] = new sqliteInt("elementID", "INTEGER PRIMARY KEY AUTOINCREMENT");

            // date time
            values[2] = new sqliteBool("isDateUsed");
            values[3] = new sqliteDateTime("time_start");
            values[4] = new sqliteDateTime("time_end");

            values[5] = new sqliteString("description");
            values[6] = new sqliteString("domain");
            values[7] = new sqliteInt("priority");
            values[8] = new sqliteInt("completion");
            values[9] = new sqliteString("team");

            // repository

            values[10] = new sqliteBool("isRepository");
            values[11] = new sqliteString("tableName");

            values[12] = new sqliteColor("color");


            // DateTime.Now.Millisecond throw Index Out of Bond exception (int to int ???), strange ...
          //  int seed = DateTime.Now.Second; same for second, seem to comme from the DateTime class
            Random r = new Random();



            Color[] cs = new Color[]{
                    Colors.Red,
                    Colors.Blue,
                    Colors.Green,
                    Colors.Yellow,
                    Colors.ForestGreen,
                    Colors.Orange,
                    Colors.Orchid,
                    Colors.Plum,
                    Colors.Pink,
                    Colors.PowderBlue,
                    Colors.Silver,
                    Colors.Tan,
                    Colors.Tomato,
                    Colors.YellowGreen
                };

            color.value = cs[r.Next(0, cs.Length)];
        }






        // other parameters:
        // =================

        public string tableName { get; set; }

        // if isRepository
        public List<calendarObject> events
        {
            get
            {
                if (isRepository.value)
                {
                    return eventsLocal;
                }
                throw new NotImplementedException();
            }
            set { eventsLocal = value; }
        }
        List<calendarObject> eventsLocal;

        public string databaseName { get; set; }


        // others


    }
}