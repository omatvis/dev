using System.Collections;
using System;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerator e = new Countdown();
            while (e.MoveNext())
                Console.Write(e.Current);
            Console.WriteLine();

            RichTextBox r = new();
            r.Undo();              // RichTextBox.Undo
            ((IUndoable)r).Undo(); // RichTextBox.Undo
            ((TextBox)r).Undo();   // RichTextBox.Undo

            Console.ReadKey();
        }
    }
}
