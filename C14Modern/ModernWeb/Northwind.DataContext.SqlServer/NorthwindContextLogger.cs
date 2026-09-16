using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataContext.SqlServer
{
    public class NorthwindContextLogger
    {
        public static void WriteLog(string message)
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "book-logs");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string dateTimeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string path = Path.Combine(folder, $"northwindlog-{dateTimeStamp}.txt");

            using StreamWriter logFile = File.AppendText(path);
            logFile.WriteLine(message);
        }
    }
}
