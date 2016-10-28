using SQL_lite_database_search_wpf.Core.DatabaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf
{
    public class RequestBuilder
    {
        public class NewElement
        {
            public static  string createRequest(calendarObject c)
            {
                string[] elementValues = getElementNames(c);
                string sql_addTable = "insert into " + c.tableName + " (" + elementValues[0] + ") values (" + elementValues[1] + ")";
                return sql_addTable;
            }
            public static string[] getElementNames(calendarObject c)
            {
                Request rb = new Request();
                rb.addElement("name", c.name);
                rb.addElement("priorite", c.priorite);
                rb.addElement("time_start", c.startTime.ToBinary());
                rb.addElement("description", c.description);
                rb.addElement("time_end", c.endTime.ToBinary());
                rb.addElement("completion", c.completion);
                rb.addElement("equipe", c.equipe);

                string[] elements = { rb.elementsNamesValue, rb.elementsValue };
                return elements;
            }
        }
        public class UpdateElement
        {

        }


    }
}
