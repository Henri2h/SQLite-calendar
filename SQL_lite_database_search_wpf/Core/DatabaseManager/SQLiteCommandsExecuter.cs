
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager
{
    public class SQLiteCommandsExecuter
    {
        static SQLiteConnection m_dbConnection { get { return Core.AppCore.dCore.m_dbConnection; } }

        public static void executeNonQuery(string request)
        {
            SQLiteCommand command = new SQLiteCommand(request, m_dbConnection);
            command.ExecuteNonQuery();
            /*
             * 
             * SQLiteCommand Command = "UPDATE SUBCONTRACTOR SET JobSite = NULL WHERE JobSite = @JobSite";
Command.Parameters.Add(new SQLiteParameter("@JobSite", JobSiteVariable));
command.ExecuteNonQuery();
             */
        }

        public static SQLiteDataReader executeDataReader(string request)
        {
            SQLiteCommand command = new SQLiteCommand(request, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }
        public static void select(string select, string tableName, string orderBy = "_rowid_")
        {
            string sql = "select " + select + " from " + tableName + " order by " + orderBy + " ASC";
        }

        public static void insert(calendarObject cObj)
        {
            Request.RequestBuilder rb = new Request.RequestBuilder(cObj.tableName.value);
            rb.addElement(cObj.name.valueName, cObj.name.value);
            rb.addElement(cObj.priorite.valueName, cObj.name.value);

            rb.addElement(cObj.completion.valueName, cObj.completion.value);

            rb.addElement(cObj.description.valueName, cObj.description.value);
            rb.addElement(cObj.equipe.valueName, cObj.equipe.value);

            // time
            rb.addElement(cObj.startTime.valueName, cObj.startTime.value);
            rb.addElement(cObj.endTime.valueName, cObj.endTime.value);
            rb.addElement(cObj.isDateUsed.valueName, cObj.isDateUsed.value);


            SQLiteCommand cmd = Request.CommandBuilder.getCommand(rb);
            cmd.ExecuteNonQuery();
        }

    }
}
