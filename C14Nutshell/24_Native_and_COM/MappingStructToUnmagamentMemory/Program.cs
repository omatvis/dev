using System;
using System.Runtime.InteropServices;

namespace MappingStructToUnmagamentMemory
{
    internal class Program
    {
        unsafe static void Main(string[] args)
        {
            Console.WriteLine(sizeof(MySharedData));
            MySharedData d;
            MySharedData* data = &d;       // Get the address of d
            (*data).Value = 123;
            data->Letter = 'X';
            data->Numbers[10] = 1.45f;


            // Allocate the array on the stack:
            MySharedData* data1 = (MySharedData*)Marshal.AllocHGlobal(sizeof(MySharedData));
            try
            {
                data1->Value = 123;
                data1->Letter = 'X';
                data1->Numbers[10] = 1.45f;
            }
            finally
            {
                if (data1 != null)
                {
                    // Free the unmanaged memory
                    Marshal.FreeHGlobal((IntPtr)data1);
                }
            }

            using (SharedMemory.SharedMem sm = new SharedMemory.SharedMem("MyShare", false,
                         (uint)sizeof(MySharedData)))
            {
                void* root = sm.Root.ToPointer();
                MySharedData* data2 = (MySharedData*)root;
                data2->Value = 123;
                data2->Letter = 'X';
                data2->Numbers[10] = 1.45f;
                Console.WriteLine("Written to shared memory");
                Console.ReadLine();
                Console.WriteLine("Value is " + data2->Value);
                Console.WriteLine("Letter is " + data2->Letter);
                Console.WriteLine("11th Number is " + data2->Numbers[10]);
                Console.ReadLine();
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe struct MySharedData
        {
            public int Value;
            public char Letter;
            public fixed float Numbers[50];
        }
    }
}
