using SQL_lite_database_search_wpf.Core.DatabaseItems;
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




        // calendar object reader
        /// <summary>
        /// Convert reader to CalendarObject
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static calendarObject readerToCobj(SQLiteDataReader reader)
        {
            if (reader != null)
            {
                calendarObject obj = new calendarObject();
                obj.name.value = reader[obj.name.valueName].ToString();

                obj.elementID.value = Convert.ToInt32(reader[obj.elementID.valueName].ToString());

                obj.domaine.value = (reader[obj.domaine.valueName].ToString());
                obj.priorite.value = int.Parse(reader[obj.priorite.valueName].ToString());
                obj.description.value = reader[obj.description.valueName].ToString();
                obj.completion.value = int.Parse(reader[obj.completion.valueName].ToString());
                obj.equipe.value = reader[obj.equipe.valueName].ToString();

                obj.isDateUsed.value = bool.Parse(reader[obj.isDateUsed.valueName].ToString());
                if (obj.isDateUsed.value)
                {
                    obj.startTime.value = DateTime.FromBinary(long.Parse(reader[obj.startTime.valueName].ToString()));
                    obj.endTime.value = DateTime.FromBinary(long.Parse(reader[obj.endTime.valueName].ToString()));
                }
                return obj;
            }
            return null;
        }
        public static List<calendarObject> readerToCobjs(SQLiteDataReader reader)
        {
            List<calendarObject> cObjs = new List<calendarObject>();
            while (reader.Read())
            {
                if (reader != null)
                {
                    cObjs.Add(readerToCobj(reader));
                }
            }
            return cObjs;
        }

        // projects reader
        public static void readerToProject(SQLiteDataReader reader)
        {
            if (reader != null)
            {
                prj.events = new List<calendarObject>();
                prj.name.value = reader[prj.name.valueName].ToString();
                prj.tableName.value = reader[prj.name.valueName].ToString();

                prj.projectTableName = prj.name.value + "Events";
               
            }
            
        }
        public static List<Project> readerToProjects(SQLiteDataReader reader)
        {

            List<Project> projects = new List<Project>();
            while (reader.Read())
            {
                if (reader != null)
                {
                    projects.Add(readerToProject(reader));
                }
            }
            return projects;
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
