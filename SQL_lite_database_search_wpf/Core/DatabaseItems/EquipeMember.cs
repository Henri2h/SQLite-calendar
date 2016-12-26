using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseItems
{
    public class EquipeMember
    {
        public sqliteString name { get { return (sqliteString)values[0]; } set { values[0] = value; } }
        public sqliteInt id { get { return (sqliteInt)values[1]; } set { values[1] = value; } }

        public sqliteBase[] values = new sqliteBase[]
          {
            new sqliteString("name"),
            new sqliteInt("memberID",  "INTEGER PRIMARY KEY AUTOINCREMENT"),
          };

    }
}
