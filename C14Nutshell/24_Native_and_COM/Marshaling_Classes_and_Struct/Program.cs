using System;
using System.Runtime.InteropServices;

namespace Marshaling_Classes_and_Struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SystemTime t = new SystemTime();
            GetSystemTime(t);
            Console.WriteLine(t.Year);
        }

        [DllImport("kernel32.dll")]
        static extern void GetSystemTime(SystemTime t);
    }

    [StructLayout(LayoutKind.Sequential)]
    class SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort Milliseconds;
    }
}
