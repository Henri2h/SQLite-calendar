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

        public sqliteBool isDateUsed = new sqliteBool("isDateUsed");
        public sqliteDateTime startTime = new sqliteDateTime("time_start");
        public sqliteDateTime endTime = new sqliteDateTime("time_end");

        public sqliteString description = new sqliteString("description");
        public sqliteString domaine = new sqliteString("domaine");

        public sqliteInt priorite = new sqliteInt("priorite");
        public sqliteInt completion = new sqliteInt("completion");
        public sqliteString equipe = new sqliteString("tableName");
        public Color c = new Color();

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

        public string tableName { get; set; }
        /// <summary>
        /// Create a request in order to create and write into the database this object
        /// </summary>
        /// <returns></returns>
        public string createRequest()
        {
            string[] elementValues = getElementNames();
            string sql_addTable = "insert into " + this.tableName + " (" + elementValues[0] + ") values (" + elementValues[1] + ")";
            return sql_addTable;
        }

        /// <summary>
        /// list the elements names
        /// </summary>
        /// <returns></returns>
        public string[] getElementNames()
        {
            Request rb = new Request();
            rb.addElement(this.name.valueName, this.name.value);
            rb.addElement(this.priorite.valueName, this.priorite.value);
            rb.addElement(this.startTime.valueName, this.startTime.value.ToBinary());
            rb.addElement(this.description.valueName, this.description.value);
            rb.addElement(this.endTime.valueName, this.endTime.value.ToBinary());
            rb.addElement(this.completion.valueName, this.completion.value);
            rb.addElement(this.equipe.valueName, this.equipe.value);
            rb.addElement(this.isDateUsed.valueName, this.isDateUsed.value.ToString());


            string[] elements = { rb.elementsNamesValue, rb.elementsValue };
            return elements;
        }
    }
}