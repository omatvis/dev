using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public Rectangle(double length, double width) : base("Rectangle")
        {
            Length = length;
            Width = width;
            Console.WriteLine($"Rectangle Constructor: {Name}");
        }
        public Rectangle() : this(1.0, 1.0) { } // Default constructor
        public double Area()
        {
            return Length * Width;
        }
        public double Perimeter()
        {
            return 2 * (Length + Width);
        }
    }
}
