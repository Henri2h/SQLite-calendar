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
    public class calendarObject : DatabaseItem
    {

        // ==============  data values ==============
        public sqliteBase[] Values = new sqliteBase[13];

        public sqliteBase[] values
        {
            get { return Values; }
            set { Values = value; }
        }


        // data access:
        //=============

        // definitions
        public sqliteString name { get { return (sqliteString)Values[0]; } set { Values[0] = value; } }
        public sqliteInt elementID { get { return (sqliteInt)Values[1]; } set { Values[1] = value; } }


        // date
        public sqliteBool isDateUsed { get { return (sqliteBool)Values[2]; } set { Values[2] = value; } }
        public sqliteDateTime startTime { get { return (sqliteDateTime)Values[3]; } set { Values[3] = value; } }
        public sqliteDateTime endTime { get { return (sqliteDateTime)Values[4]; } set { Values[4] = value; } }

        public sqliteString description { get { return (sqliteString)Values[5]; } set { Values[5] = value; } }
        public sqliteString domaine { get { return (sqliteString)Values[6]; } set { Values[6] = value; } }

        public sqliteInt priorite { get { return (sqliteInt)Values[7]; } set { Values[7] = value; } }
        public sqliteInt completion { get { return (sqliteInt)Values[8]; } set { Values[8] = value; } }

        /// <summary>
        /// Team member list
        /// </summary>
        // TODO : implement it as a list of all the team members evolved in it
        public sqliteString equipe { get { return (sqliteString)Values[9]; } set { Values[9] = value; } }

        // table and repository
        public sqliteBool isRepository { get { return (sqliteBool)Values[10]; } set { Values[10] = value; } }
        public sqliteString projectTableName { get { return (sqliteString)Values[11]; } set { Values[11] = value; } }

        // color
        public sqliteColor color { get { return (sqliteColor)Values[12]; } set { Values[12] = value; } }


        public calendarObject() { createCalendarObject(); }
        public calendarObject(string name)
        {
            createCalendarObject();
            this.name.value = name;
        }

        public void createCalendarObject()
        {
            Values[0] = new sqliteString("name");
            Values[1] = new sqliteInt("elementID", "INTEGER PRIMARY KEY AUTOINCREMENT");

            // date time
            Values[2] = new sqliteBool("isDateUsed");
            Values[3] = new sqliteDateTime("time_start");
            Values[4] = new sqliteDateTime("time_end");

            Values[5] = new sqliteString("description");
            Values[6] = new sqliteString("domain");
            Values[7] = new sqliteInt("priority");
            Values[8] = new sqliteInt("completion");
            Values[9] = new sqliteString("team");

            // repository

            Values[10] = new sqliteBool("isRepository");
            Values[11] = new sqliteString("tableName");

            Values[12] = new sqliteColor("color");

            setRandValueForColor();
        }

        void setRandValueForColor()
        {
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

            Random r = new Random(DateTime.Now.Millisecond);
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
                throw new NullReferenceException();
            }
            set { eventsLocal = value; }
        }
        List<calendarObject> eventsLocal;

        public bool isMoreThanOneDay
        {
            get
            {
                if (this.isDateUsed.value == true)
                {
                    TimeSpan ts = this.endTime.value.Date - this.startTime.value.Date;
                    if (ts.Days == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public string databaseName { get; set; }



        // others


    }
}