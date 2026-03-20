using System.Diagnostics.CodeAnalysis;

namespace Packt.Shared
{
    public class Person (string name, DateTimeOffset born)
    {
        public string? Name { get; set; } = name;
        public DateTimeOffset Born { get; set; } = born;

        public readonly string HomePlanet = "Earth";

        public required int Age { get; set; }

        public Person(string name): this(name, default)
        {
            Age = 0;
        }

        [SetsRequiredMembers]
        public Person() : this("UNKNOWN", default)
        {
            HomePlanet = "";
            Age = 0;
        }

    }
}
