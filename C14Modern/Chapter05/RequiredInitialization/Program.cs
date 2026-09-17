using System.Diagnostics.CodeAnalysis;

namespace RequiredInitialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Name = "John"
            };
            Console.WriteLine(person.ToString());

            ImmutablePerson immutablePerson = new ImmutablePerson()
            {
                Name = "Jane"
            };
            
            Console.WriteLine($"{nameof(immutablePerson)} , { typeof(ImmutablePerson)}");
        }
    }

    public class Person {
        private string name = string.Empty;

        public required string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value), "Name cannot be null.");
        }

        public Person() { }
        [SetsRequiredMembers]
        public Person(string name)
        {
            Name = name;
        }
        
        public override string ToString()
        {
            return $"Person: {Name}";
        }

    }

    public class ImmutablePerson
    {
        public readonly string name = string.Empty;
        public string Name
        {
            get => name;
            init => name ??= value;
        }

        public ImmutablePerson() { }
        public ImmutablePerson(string name)
        {
            Name = name;
        }
    }
}
