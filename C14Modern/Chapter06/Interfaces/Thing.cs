using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Interfaces
{
    public class Thing: IComparable<Thing>
    {
        private static int _nextId = 1;
        public int Id { get; }

        public Thing()
        {
            Id = _nextId++;
        }

        public int CompareTo(Thing? other)
        {
            other??= new Thing();
            return Id.CompareTo(other.Id);
        }
    }

    public class  ThingWithColor: Thing
    {
        public Color Colour { get; set; }
    }

    public class ThingWithSize : Thing
    {
        public Size Size { get; set; }
    }
}
