using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager
{
    public class ObjectManager
    {
        SQLiteConnection m_dbConnection { get { return Core.AppCore.dCore.m_dbConnection; } }
       

        //add data
        public void addDataTable(string tableName, string row, string values)
        {
            try
            {

                string sql_addTable = "insert into " + tableName + " (" + row + ") values (" + values + ")";
                SQLiteCommand command_addTable = new SQLiteCommand(sql_addTable, m_dbConnection);
                command_addTable.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                ex.Source = "db_SQLite.addDataTable";
                ErrorHandeler.ErrorMessage.printOut(ex);

                Core.AppCore.Wi.showMessageBox(ex.Message, "SQLite Error");
            }
        }
    }
}
