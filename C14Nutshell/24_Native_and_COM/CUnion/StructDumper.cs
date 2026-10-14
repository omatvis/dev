using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CUnion
{
    public interface IPrintableSpan
    {
        void Print(ReadOnlySpan<byte> bytes);
    } 
    
    public class PrintableSpan : IPrintableSpan
    {
        public void Print(ReadOnlySpan<byte> bytes)
        {
            int totalBits = bytes.Length * 8;
            Console.WriteLine("Bits (index : value)  -- global index, LSB-first within each byte");
            for (int b = 0; b < bytes.Length; b++)
            {
                byte by = bytes[b];
                for (int bit = 0; bit < 8; bit++)
                {
                    int globalBitIndex = b * 8 + bit;
                    int bitValue = (by >> bit) & 1;
                    Console.WriteLine($"bit {globalBitIndex,3}: {bitValue}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Bytes (index : value decimal)");
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.WriteLine($"byte {i,3}: {bytes[i]}");
            }
        }
    }

    public class StructMemoryDumper 
    {
        private static readonly IPrintableSpan _printer = new PrintableSpan();

        public void Print(ReadOnlySpan<byte> bytes)
        {
            _printer.Print(bytes);
        }

        // Dumps bit index (global, LSB-first per byte) and byte index/value (decimal).
        public unsafe void DumpBitsAndBytes<T>(ref T value) where T : struct
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                // Non-blittable fallback: marshal to unmanaged memory
                int size = Marshal.SizeOf<T>();
                IntPtr ptr = Marshal.AllocHGlobal(size);
                try
                {
                    Marshal.StructureToPtr(value, ptr, false);
                    Span<byte> bytes = new Span<byte>(ptr.ToPointer(), size);
                    Print(bytes);
                }
                finally
                {
                    Marshal.FreeHGlobal(ptr);
                }
            }
            else
            {
                // Blittable path: read bytes directly
                Span<byte> bytes = MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref value, 1));
                Print(bytes);
            }
        }
    }
}