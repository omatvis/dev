using Packt.Shared;

namespace PeopleApp;

partial class Program
{
    static void OutputPeoplenames(IEnumerable<Person?> people, string title) {
        Console.WriteLine(title);
        foreach (Person? person in people) 
        {
            Console.WriteLine("   {0}", person is null ? "<null> Person" : person.Name ?? "<null> Name");
        }
    }
}
