namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animals<Cat> animals = new Animals<Cat>();
            animals.Add(new Cat("Buddy"));
            animals.Add(new Cat("Whiskers"));
            // animals.Add(new Animal("Tusk")); // FIX: Remove this line, as Animals<Cat> only accepts Cat instances
        }
    }
}
