using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle: Shape
    {
        public double Radius { get; set; }
        public Circle(double radius) : base("Circle")
        {
            Radius = radius;
            Console.WriteLine($"Circle Constructor: {Name}");
        }
        public Circle() : this(1.0) { } // Default constructor
        public double Area()
        {
            return Math.PI * Radius * Radius;
        }
        public double Circumference()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
