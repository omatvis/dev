namespace PandaPopulation
{
    public class Panda
    {
        public string Name; // Instance field
        public static int Population; // Static field

        public Panda(string n) // Constructor
        {
            Name = n; // Assign the instance field
            Population++; // Increment the static Population field
        }
    }
}