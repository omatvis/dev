using System;
using System.Xml.Linq;

namespace AssembliesAndNamespaces;

class Program
{
    static void Main(string[] args)
    {
        XDocument doc = new();

        string s1 = "Hello";
        String s2 = "World";
        WriteLine($"{s1} {s2}");
    }
}
