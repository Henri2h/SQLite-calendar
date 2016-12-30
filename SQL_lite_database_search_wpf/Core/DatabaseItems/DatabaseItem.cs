using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;

namespace SQL_lite_database_search_wpf.Core.DatabaseItems
{
    public interface DatabaseItem
    {
        sqliteBase[] values { get; set; }
        void createCalendarObject();

        // needed type
        sqliteInt elementID { get; set; }

        string tableName { get; set; }
    }
}
