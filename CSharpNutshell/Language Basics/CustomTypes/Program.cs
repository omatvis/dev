namespace CustomTypes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UnitConverter feetToInchesConverter = new(12);
            UnitConverter milesToFeetConverter = new(5280);
            Console.WriteLine(feetToInchesConverter.Convert(30));
            Console.WriteLine(feetToInchesConverter.Convert(100));

            Console.WriteLine(feetToInchesConverter.Convert(milesToFeetConverter.Convert(1)));
        }
    }
}