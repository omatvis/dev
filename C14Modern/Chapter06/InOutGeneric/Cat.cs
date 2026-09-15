using System;
using System.Collections.Generic;
using System.Text;

namespace InOutGeneric
{
    internal enum Color
    {
        Black,
        White,
        Brown,
        Grey,
        Unknown
    }

    internal class Cat: Animal
    {
        private readonly Color color;
        public Cat(string name, Color color) : base(name) { this.color = color; }

        public Color Color { get { return color; } init { color = value; } }
    }
}
