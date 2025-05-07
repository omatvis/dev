using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Shape(string name)
    {
        public string Name { get; set; } = name;
        public Shape(): this("Shape") { Console.WriteLine($"Default Constsrutor: {Name}"); }
    }
}
