using SQL_lite_database_search_wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.ErrorHandeler
{
    public class ErrorMessage
    {

        /// <summary>
        /// retrurn the representation in a string of the function
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
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


        /// <summary>
        /// print the error in the console and save the error
        /// </summary>
        /// <param name="ex"></param>
        public static void printOut(Exception ex)
        {
            string err = getErrorString(ex);
            Console.WriteLine(err);
            System.Diagnostics.Debug.WriteLine(err);

            string tempFile = Files.getTempFile(".err");
            File.AppendAllText(tempFile, err);
        }

        /// <summary>
        /// just to save the error without printing the error
        /// </summary>
        /// <param name="ex"></param>
        public static void saveOut(Exception ex)
        {

            string err = getErrorString(ex);
            string tempFile = Files.getTempFile(".err");
            File.AppendAllText(tempFile, err);
        }

        public static void logError(Exception ex)
        {

            string err = getErrorStringJson(ex) + Environment.NewLine;
            Console.WriteLine(err);
            System.Diagnostics.Debug.WriteLine(err);

            try
            {
                File.AppendAllText(Environment.CurrentDirectory + "\\error.log", err);
            }
            catch
            {
                string tempFile = Files.getTempFile(".err");
                File.AppendAllText(tempFile, err);
            }

        }
        public static string getErrorStringJson(Exception ex) { return Newtonsoft.Json.JsonConvert.SerializeObject(ex); }

    }
}
