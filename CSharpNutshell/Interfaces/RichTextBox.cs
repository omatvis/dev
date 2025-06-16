using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class RichTextBox: TextBox
    {
        public override void Undo()
        {
            Console.WriteLine("Undo operation in RichTextBox executed.");
        }
    }
}
