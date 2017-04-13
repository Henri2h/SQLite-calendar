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
        public const string elementID = "elementID";

        public void CreateCalendarTable(string tableName)
        {
            calendarObject cObj = new calendarObject();

            StringBuilder sbElements = new StringBuilder();
            {
                bool justCreated = true;

                foreach (sqliteBase sElement in cObj.values)
                {
                    if (justCreated) { justCreated = false; }
                    else { sbElements.Append(", "); }
                    sbElements.Append(sElement.valueName + " " + sElement.dataType);

                }
            }

            string sql_command = "CREATE TABLE " + tableName + " ( " + sbElements.ToString() + ")";
            SQLiteCommandsExecuter.executeNonQuery(sql_command, Core.AppCore.dCore.M_dbConnection);
        }


        /// <summary>
        /// Add the calendar object to the table and create it associated projecttablename if needed
        /// </summary>
        /// <param name="cObj"></param>
        public void AddCalendarObject(calendarObject cObj, bool createAssociatedTable = false)
        {
            try
            {
                if (cObj.tableName == null) { throw new ArgumentNullException(); }

                // associate project table name :
                // ============

                if (cObj.isRepository.value)
                {
                    if ((cObj.isRepository.value && createAssociatedTable) || (cObj.projectTableName.value == null || cObj.projectTableName.value == ""))
                    {
                        cObj.projectTableName.value = "Element_" + Guid.NewGuid().ToString("n") + "_Tasks";
                    }
                    // else just use the current table name
                    CreateCalendarTable(cObj.projectTableName.value);

                }

                Request.RequestBuilder rb = new Request.RequestBuilder(cObj.tableName);
                foreach (sqliteBase sb in cObj.values)
                {
                    rb.addElement(sb.valueName, sb.baseValue);
                }

                SQLiteCommand cmd = Request.CommandBuilder.getCommand(rb, Core.AppCore.dCore.M_dbConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.Source = "SQL_lite_database_search_wpf.Core.DatabaseManager.ObjectsManager.CalendarObjectManager.addCalendarObject";
                Usefull_Tools.ErrorHandeler.printOut(ex);

            }

        }
        public void DeleteCalendarObject(int id, string tableName)
        {
            sqliteInt sIntID = new sqliteInt("elementID")
            {
                value = id
            };
            AppCore.dCore.DelElement(tableName, sIntID);
        }
        public void DeleteCalendarObject(calendarObject cObj, bool deleteAssociatedTable = true)
        {
            if (deleteAssociatedTable)
            {
                if (cObj.isRepository.value) { DeleteCalendarTable(cObj.projectTableName.value); }
            }

            DeleteCalendarObject(cObj.elementID.value, cObj.tableName);
        }

        public void DeleteCalendarTable(string tableName, bool deleteAssociatedTable = true)
        {
            if (deleteAssociatedTable)
            {
                List<calendarObject> cObjs = ListCalendarObjects(tableName);

                foreach (calendarObject c in cObjs)
                {
                    if (c.isRepository.value) { DeleteCalendarTable(c.projectTableName.value); }
                }
            }
            Core.AppCore.dCore.DelTable(tableName);
        }


        public calendarObject GetCalendarObject(int objectID, string tableName)
        {
            string sql = "select * from " + tableName + " where (" + elementID + "=" + objectID + ")  order by _rowid_ ASC LIMIT 1";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql, Core.AppCore.dCore.M_dbConnection);
            calendarObject cObjects = ReaderToCobj(reader, tableName);
            return cObjects;

        }


        public List<calendarObject> ListCalendarObjects(string tableName)
        {
            string sql = "select * from " + tableName + " order by _rowid_ ASC";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql, Core.AppCore.dCore.M_dbConnection);
            List<calendarObject> cObjects = ReaderToCobjs(reader, tableName);
            return cObjects;
        }

        public List<calendarObject> ListALLCalendarObjects(string tableName, List<calendarObject> cObjs = null)
        {
            if (cObjs == null) { cObjs = new List<calendarObject>(); }

            string sql = "select * from " + tableName + " order by " + elementID + " ASC";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql, Core.AppCore.dCore.M_dbConnection);
            foreach (calendarObject cObj in ReaderToCobjs(reader, tableName))
            {
                cObjs.Add(cObj);
                if (cObj.isRepository.value)
                {
                    cObjs = ListALLCalendarObjects(cObj.projectTableName.value, cObjs);
                }
            }


            return cObjs;
        }

        public enum SelectionType
        {
            isDateUsed,
            isRepository
        }
        public List<calendarObject> ListAllCalendarObjectsBySelection(string tableName, SelectionType selType, List<calendarObject> cObjs = null)
        {
            if (cObjs == null) { cObjs = new List<calendarObject>(); }

            string sql = "select * from " + tableName + " order by " + elementID + " ASC";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql, Core.AppCore.dCore.M_dbConnection);

            foreach (calendarObject cObj in ReaderToCobjs(reader, tableName))
            {
                if (cObj.isDateUsed.value && selType == SelectionType.isDateUsed) { cObjs.Add(cObj); }
                if (cObj.isRepository.value && selType == SelectionType.isRepository) { cObjs.Add(cObj); }

                if (cObj.isRepository.value && selType == SelectionType.isDateUsed)
                {
                    cObjs = ListAllCalendarObjectsBySelection(cObj.projectTableName.value, selType, cObjs);
                }
                else if (cObj.isRepository.value && selType == SelectionType.isRepository)
                {
                    cObjs = ListAllCalendarObjectsBySelection(cObj.projectTableName.value, selType, cObjs);
                }
            }

            return cObjs;
        }


        public void UpdateCalendarObject(sqliteBase sb, int objectID, string tableName)
        {
            string request = "UPDATE " + tableName + " SET " + sb.valueName + " = " + "@param" + " WHERE " + elementID + " = " + objectID;

            SQLiteCommand Command = new SQLiteCommand(request, Core.AppCore.dCore.M_dbConnection);
            Command.Parameters.AddWithValue("@param", sb.baseValue);

            int updated = Command.ExecuteNonQuery();
            Console.WriteLine(updated + "row upadted");
        }


        // update or save, the same thing
        public void UpdateCalendarObject(calendarObject cObj)
        {

            calendarObject old = GetCalendarObject(cObj.elementID.value, cObj.tableName);
            for (int i = 0; i < cObj.values.Length; i++)
            {
                if (cObj.values[i].Equals(old.values[i]) == false)
                {
                    UpdateCalendarObject(cObj.values[i], cObj.elementID.value, cObj.tableName);
                }
            }

        }

        public calendarObject ReaderToCobj(SQLiteDataReader reader, string tableName, bool useReaderRead = true)
        {
            if (useReaderRead) { reader.Read(); }

            if (reader != null)
            {
                bool hasRows = reader.HasRows;

                calendarObject obj = new calendarObject();

                for (int i = 0; i < obj.values.Length; i++)
                {
                    obj.values[i].baseValue = reader[obj.values[i].valueName];
                }

                obj.tableName = tableName;

                return obj;
            }
            return null;
        }

        public List<calendarObject> ReaderToCobjs(SQLiteDataReader reader, string tableName)
        {
            List<calendarObject> cObjs = new List<calendarObject>();
            while (reader.Read())
            {
                if (reader != null)
                {
                    cObjs.Add(ReaderToCobj(reader, tableName, false));
                }
            }
            return cObjs;
        }




    }
}
