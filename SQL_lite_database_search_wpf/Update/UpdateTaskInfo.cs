using System;

namespace SQL_lite_database_search_wpf
{
    internal class UpdateTaskInfo
    {
        // TaskDescription?
        public string FileDescription { get; set; }
        public string FileName { get; set; }
        public string FileVersion { get; set; }
        public long? FileSize { get; set; }
        public DateTime? FileDate { get; set; }
    }
}