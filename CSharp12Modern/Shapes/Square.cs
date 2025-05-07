using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square: Rectangle
    {
        public Square(double length): base(length, length) { Name = "Square"; }
    }
}
