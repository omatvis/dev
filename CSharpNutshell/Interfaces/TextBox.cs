using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class TextBox: IUndoable
    {
        public virtual void Undo()
        {
            Console.WriteLine("Undo operation in TextBox executed.");
        }
    }
}
