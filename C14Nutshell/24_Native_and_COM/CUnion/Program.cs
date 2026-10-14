using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace CUnion
{
    public static partial class Program
    {
        static void Main(string[] args)
        {
            var message = new NoteMessage
            {
                Channel = 0,
                Note = 1,
                Velocity = 0
            };

            new StructMemoryDumper().DumpBitsAndBytes(ref message);
            Console.WriteLine(message.PackedMsg);
            Console.WriteLine(midiOutShortMsg(IntPtr.Zero, message.PackedMsg));
        }

        [LibraryImport("winmm.dll")]
        public static partial uint midiOutShortMsg(IntPtr handle, uint message);
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct NoteMessage
    {
        [FieldOffset(0)] public uint PackedMsg;    // 4 bytes long
        [FieldOffset(0)] public byte Channel;      // FieldOffset also at 0
        [FieldOffset(1)] public byte Note;
        [FieldOffset(2)] public byte Velocity;
    }
}
