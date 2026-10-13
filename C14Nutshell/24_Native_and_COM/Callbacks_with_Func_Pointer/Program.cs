using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices; // <--- add this

namespace Callbacks_with_Func_Pointer
{
    internal unsafe class Program
    {
        static void Main(string[] args)
        {
            EnumWindows(&PrintWindow, IntPtr.Zero);
        }

        [DllImport("user32.dll")]
        static extern int EnumWindows(delegate* unmanaged[Stdcall]<IntPtr, IntPtr, byte> hWnd, IntPtr lParam);

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        static byte PrintWindow(IntPtr hWnd, IntPtr lParam)
        {
            Console.WriteLine(hWnd.ToInt64());
            return 1;
        }
    }
}
