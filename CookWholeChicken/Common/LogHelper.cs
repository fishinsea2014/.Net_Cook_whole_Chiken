using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Common
{
    public class LogHelper
    {
        /// <summary>
        /// The static constructor completes the path creation without having to determine the path every time
        /// Could have problem when delete dir after creating it.        /// 
        /// </summary>
        static LogHelper()
        {
            string rootPath = StaticConstant.LogRootPath;
            if (!Directory.Exists(rootPath))   // Directory is in system.io
            {
                Directory.CreateDirectory(rootPath);
            }
        }

        /// <summary>
        /// Basic log method.
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLog(string msg)
        {
            string rootPath = StaticConstant.LogRootPath;
            string fileName = DateTime.Now.ToString("yyyy-MM-dd.txt");
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
                WriteLog(msg);
            }

            var fullName = Path.Combine(rootPath, fileName);
            using (StreamWriter sw = File.AppendText(fullName))
            {
                sw.WriteLine($"{DateTime.Now}  :  {msg}");
            }
        }



        public static void WriteLogAndConsole(string msg)
        {
            Console.WriteLine(msg);
            //Console.BackgroundColor = ConsoleColor.Blue;
            WriteLog(msg);
        }
    }
}
