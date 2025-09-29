using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S13L273_ListBox.Data
{
    class Person
    {
        public int Age { get; set; }
        public string? Name { get; set; }

        public override string? ToString()
        {
            return $"{Name} is {Age} year(s) old.";
        }
    }
}
