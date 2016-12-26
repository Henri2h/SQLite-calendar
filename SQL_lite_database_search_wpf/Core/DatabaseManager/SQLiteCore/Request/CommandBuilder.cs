using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager.Request
{
    public class CommandBuilder
    {
        static SQLiteConnection m_dbConnection { get { return Core.AppCore.dCore.m_dbConnection; } }

        public static SQLiteCommand getCommand(RequestBuilder rb)
        {
            string names = "";
            string parameterNames = "";
            bool justCreated = true;

            // load names
            foreach (string name in rb.getStringElementNames())
            {
                if (justCreated) { names = name; justCreated = false; }
                else names += ", " + name;
            }


            // load parameter names
            justCreated = true;
            foreach (string parameterName in rb.getStringElementParameterNames())
            {
                if (justCreated) { parameterNames = parameterName; justCreated = false; }
                else parameterNames += ", " + parameterName;
            }

            // sqlite command
            string sql_addTable = "insert into " + rb.tableName + " (" + names + ") values (" + parameterNames + ")";

            // command and parameters
            SQLiteCommand Command = new SQLiteCommand(sql_addTable, m_dbConnection);
            foreach (RequestElement parameter in rb.getElements())
            {
                Command.Parameters.Add(parameter.parameterName);
            }

            return Command;
        }



    }
}
