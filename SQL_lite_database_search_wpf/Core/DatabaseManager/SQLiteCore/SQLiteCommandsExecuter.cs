
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
        public static void executeNonQuery(string request, SQLiteConnection m_dbConnection)
        {
            SQLiteCommand command = new SQLiteCommand(request, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public static SQLiteDataReader executeDataReader(string request, SQLiteConnection m_dbConnection)
        {
            SQLiteCommand command = new SQLiteCommand(request, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

    }
}
