using System.Text;

namespace StringTypes;

class Program
{
    static void Main(string[] args)
    {
        string s = "Test\n\tAgain Test."; // Literal string
        System.Console.WriteLine(s);
        s = @"Test\n\tAgain Test."; // Verbatim string
        System.Console.WriteLine(s);
        s = $"Test\n\tAgain Test."; // Interpolated string
        System.Console.WriteLine(s);
        s = """Test\n\tAgain Test."""; // raw string literal
        System.Console.WriteLine(s);
        float s1 = 56.99999999999f;
        System.Console.WriteLine(s + 44); // 5644
        System.Console.WriteLine($"{s1, 10:N5} | {s1, -10:N5}");
        int i = 25;
        System.Console.WriteLine(((decimal)i).ToString());

        Person person = new("Alana", new(1990, 01, 01)) { Description = "", Sex = 'F' };

        System.Console.WriteLine($"Person ToString(): {person[5]}");

        Book book = new Book() { Name = "0", Pages = 35, };
    }
}

class Person(string name, DateOnly dateOfBirth)
{
    public string? Con { get; init; }
    public string? Name = name;
    public DateOnly DateOfBirth = dateOfBirth;
    public string? Description;

    public char Sex;

    public Person(string name, DateOnly dateOfBirth, string? description)
        : this(name, dateOfBirth)
    {
        Description = description;
    }

    private bool disposed = false;

    public void Dispose() // for call by a developer is the class is a lib
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;
        // .. deallocation unmanaged resources
        if (disposing)
        {
            // deallocation of any other managed resources
            // ...
            disposed = true;
        }
    }

    ~Person()
    {
        Dispose(false);
    }

    public Person this[int index]
    {
        get { return this; }
    }

    public override string ToString()
    {
        return new StringBuilder()
            .Append("Type: ")
            .Append(base.ToString())
            .Append(" ")
            .Append(this.Name)
            .Append(" ")
            .Append(this.Description)
            .ToString();
    }
}

public record Vehicle
{
    public string? Wheels { get; init; }
    public string? Color { get; init; }
}

public class Book
{
    private string? name;
    private int? pages;

    public Book() { }

    public Book(string name, int pages)
    {
        Name = name;
        Pages = pages;
        Color = default;
    }

    public required string? Name
    {
        get => name;
        set => name = value;
    }
    public required int? Pages
    {
        get => pages;
        set => pages = value;
    }

    public int Color { get; init; }

    public int this[int index] => index;
}
