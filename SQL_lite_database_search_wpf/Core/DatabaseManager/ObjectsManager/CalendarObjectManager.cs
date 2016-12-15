using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager.ObjectsManager
{
    public class CalendarObjectManager
    {

        public void createCalendarTable(string tableName)
        {
            string sql_command = "CREATE TABLE " +
                tableName +
                " (" +

                "name Text, " +
                "domaine Text, " +
                "priorite INT, " +
                "description TEXT, " +

                // time
                "time_start TEXT, " +
                "time_end TEXT, " +
                "isDateUsed BLOB , " +

                "completion INT, " +

                // equipe: JSON string of list of member ids
                "equipe TEXT, " +

                //associate table name
                "isRepository," +
                "tableName TEXT" +

                ")";
            SQLiteCommandsExecuter.executeNonQuery(sql_command);
        }


        public void addCalendarObject(calendarObject cObj) { }

        public void deleteCalendarObject(int id, string tableName)
        {
            AppCore.dCore.delElement(tableName, id);
        }

        public calendarObject getCalendarObject(string objectID, string tableName)
        {
            string sql = "select * from " + tableName + " order by _rowid_ ASC";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql);
            calendarObject cObjects = ObjectManager.readerToCobj(reader);
            return cObjects;

        }
        public List<calendarObject> listCalendarObjects(string tableName)
        {
            string sql = "select * from " + tableName + " order by _rowid_ ASC";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql);
            List<calendarObject> cObjects = ObjectManager.readerToCobjs(reader);
            return cObjects;
        }


        public void updateCalendarObject(sqliteBase sb, int objectID, string tableName)
        {

            string request = "update " + tableName + " set '" + sb.valueName + "'='" + sb.value + "' where '_rowid_'='" + objectID + "'";
            SQLiteCommandsExecuter.executeNonQuery(request);

        }
    }
}
