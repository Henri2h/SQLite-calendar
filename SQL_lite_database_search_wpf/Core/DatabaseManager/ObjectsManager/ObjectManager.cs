using SQL_lite_database_search_wpf.Core.DatabaseItems;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Media;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager
{
    public class ObjectManager
    {
        SQLiteConnection m_dbConnection { get { return Core.AppCore.dCore.m_dbConnection; } }




        // calendar object reader
        /// <summary>
        /// Convert reader to CalendarObject
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static calendarObject readerToCobj(SQLiteDataReader reader, string tableName)
        {
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
        public static List<calendarObject> readerToCobjs(SQLiteDataReader reader, string tableName)
        {
            List<calendarObject> cObjs = new List<calendarObject>();
            while (reader.Read())
            {
                if (reader != null)
                {
                    cObjs.Add(readerToCobj(reader, tableName));
                }
            }
            return cObjs;
        }



        public static List<EquipeMember> getEquipeFromReader(SQLiteDataReader reader)
        {
            List<EquipeMember> equipeMemeber = new List<EquipeMember>();
            while (reader.Read())
            {
                EquipeMember mb = new EquipeMember();
                mb.name.value = reader[mb.name.valueName].ToString();
                mb.id.value = int.Parse(reader[mb.id.valueName].ToString());


                equipeMemeber.Add(mb);
            }

            return equipeMemeber;

        }

    }
}
