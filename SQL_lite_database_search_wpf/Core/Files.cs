using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf
{
    public class Files
    {
        // temp files and dir
        public static string getTempFile(string extention)
        {
            string file = Path.GetTempPath();
            string name = "current";
            int version = 0;
            while (File.Exists(file + name + version + extention))
            {
                version++;
            }
            return file + name + version + extention;
        }

        public static string getTempDir()
        {
            return Path.GetTempPath();
        }


    }
}
