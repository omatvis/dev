namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Thing> things = new List<Thing>()
            {
                new ThingWithColor() { Colour = System.Drawing.Color.AntiqueWhite },
                new ThingWithSize() { Size = new System.Drawing.Size(100, 200) },
                new Thing(),
                new ThingWithColor() { Colour = System.Drawing.Color.Black },
            };

            things.Sort();
            foreach (var thing in things)
            {
                Console.WriteLine($"Thing {thing.Id}");
            }

        }
    }
}
