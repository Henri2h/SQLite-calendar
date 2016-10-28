using SQL_lite_database_search_wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.ErrorHandeler
{
  public  class ErrorMessage
    {
        public static string getErrorString(Exception ex)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("New error : ");
            output.AppendLine("Message : " + ex.Message);
            output.AppendLine("Inner exception : " + ex.InnerException);
            output.AppendLine("Source : " + ex.Source);
            output.AppendLine("Data : " + ex.Data);
            output.AppendLine("Stack Trace : " + ex.StackTrace);

            return output.ToString();
        }
        public static void printOut(Exception ex)
        {
            string err = getErrorString(ex);
            Console.WriteLine(err);
            string tempFile = Files.getTempFile(".err");

            File.AppendAllText(tempFile, err);
            //  files.saveFile(".err", err + Environment.NewLine + tempFile);
        }
        public static void saveOut(Exception ex)
        {
            //just to save without printing the error
            string err = getErrorString(ex);
            string tempFile = Files.getTempFile(".err");

            File.AppendAllText(tempFile, err);
            //  files.saveFile(".err", err + Environment.NewLine + tempFile);
        }

        
    }
}
