using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string b = "test";
        string c = "test";
        System.Console.WriteLine(b == c); // true - string reference type implements value type comparison

        string a1 = "\\\\server\\fileshare\\helloworld.cs"; // single string
        string a2 = @"\\server\fileshare\helloworld.cs"; // verbatim string
        System.Console.WriteLine(a1 == a2);

        string escaped = "First Line\r\nSecond Line";
        string verbatim =
            @"First Line
Second Line";
        // True if your text editor uses CR-LF line separators:
        Console.WriteLine(escaped == verbatim);
        string xml = @"<customer id=""123""></customer>";
        System.Console.WriteLine(xml);
        string raw = """<file path="c:\temp\test.txt"></file>""";
        System.Console.WriteLine(raw);
        int x = 4;
        Console.Write($"A square has {x} sides"); // Prints: A square has 4 sides. String interpolation
    }
}
