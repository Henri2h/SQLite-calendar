using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseItems.objects
{
    public class sqliteBool : sqliteBase
    {
        public sqliteBool(string Name) : base(Name) { }
        public bool value { get; set; }
    }
    public class sqliteInt : sqliteBase
    {
        public sqliteInt(string Name) : base(Name) { }
        public int value { get; set; }
    }
    public class sqliteString : sqliteBase
    {
        public sqliteString(string Name) : base(Name) { }
        public string value { get; set; }
    }
    public class sqliteDateTime : sqliteBase
    {
        public sqliteDateTime(string Name) : base(Name) { }
        public DateTime value { get; set; }
    }
}
