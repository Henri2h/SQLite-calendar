using SQL_lite_database_search_wpf.Core.DatabaseItems;
using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;
using SQL_lite_database_search_wpf.Core.DatabaseManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf
{
    /// <summary>
    /// base class of the calendar object
    /// </summary>
    public class calendarObject
    {
        public sqliteString name = new sqliteString("name");

        // date
        public sqliteBool isDateUsed = new sqliteBool("isDateUsed");
        public sqliteDateTime startTime = new sqliteDateTime("time_start");
        public sqliteDateTime endTime = new sqliteDateTime("time_end");

        public sqliteString description = new sqliteString("description");
        public sqliteString domaine = new sqliteString("domaine");

        public sqliteInt priorite = new sqliteInt("priorite");
        public sqliteInt completion = new sqliteInt("completion");
        public sqliteString equipe = new sqliteString("equipe");

        // table and repository
        public sqliteBool isRepository = new sqliteBool("isRepository");
        public sqliteString tableName = new sqliteString("tableName");



        public string databaseName { get; set; }


        // others
        public Color color = new Color();
        public DayManager days { get; set; }

        public bool isOneDayLenght
        {
            get
            {
                if (isDateUsed.value)
                {
                    if ((endTime.value - startTime.value).Days == 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public bool isOneWeekLenght
        {
            get
            {
                if (isDateUsed.value)
                {
                    if ((endTime.value - startTime.value).Days < 8)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

    }
}