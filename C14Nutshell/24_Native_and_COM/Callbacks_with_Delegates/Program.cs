using System;
using System.Runtime.InteropServices;

namespace Callbacks_with_Delegates
{
    internal class Program
    {
        delegate bool EnumWindowsCallback(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern int EnumWindows(EnumWindowsCallback hWnd, IntPtr lParam);
        static bool PrintWindow(IntPtr hWnd, IntPtr lParam)
        {
            Console.WriteLine(hWnd.ToInt64());
            return true;
        }
        static readonly EnumWindowsCallback printWindowFunc = PrintWindow;
        static void Main(string[] args)
        {
            EnumWindows(printWindowFunc, IntPtr.Zero);
        }
    }
}
