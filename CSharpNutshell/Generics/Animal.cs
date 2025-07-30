using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Animal: Living
    {
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"Animal: {Name}";
        }
    }
}
