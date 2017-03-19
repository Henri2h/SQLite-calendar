using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseItems
{
    public class EquipeMember : DatabaseItem
    {
        public EquipeMember() { createCalendarObject(); }

        sqliteBase[] Values = new sqliteBase[2];

        public sqliteString name { get { return (sqliteString)values[0]; } set { values[0] = value; } }
        public sqliteInt elementID { get { return (sqliteInt)values[1]; } set { values[1] = value; } }

        public sqliteBase[] values
        {
            get { return Values; }
            set { Values = value; }
        }

        public string tableName { get; set; }

        public void createCalendarObject()
        {
            Values[0] = new sqliteString("name");
            Values[1] = new sqliteInt("memberID", "INTEGER PRIMARY KEY AUTOINCREMENT");
        }
    }
}
