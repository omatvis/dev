using System;
using System.Collections.Generic;
using System.Text;
using static System.Environment;

namespace Northwind.EntityModels
{
    public class NorthwindContextLogger
    {
        public static void WriteLine(string message)
        {
            string path = Path.Combine(GetFolderPath(SpecialFolder.DesktopDirectory), "NorthwindLog.txt");
            StreamWriter textFile = File.AppendText(path);
            textFile.WriteLine(message);
            textFile.Close();
        }
    }
}
