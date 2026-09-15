using System;
using System.Collections.Generic;
using System.Text;

namespace InOutGeneric
{
    internal class Animal
    {
        public required string Name { get; set; }
        public Animal(string name) { Name = name; }
    }
}
