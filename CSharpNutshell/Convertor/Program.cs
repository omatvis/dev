using Convertor;

internal class Program
{
    private static void Main(string[] args)
    {
        UnitConverter feetToInchesConverter = new UnitConverter(12);
        UnitConverter milesToFeetConverter = new UnitConverter(5280);
        Console.WriteLine(feetToInchesConverter.Convert(30)); // 360
        Console.WriteLine(feetToInchesConverter.Convert(100)); // 1200
        Console.WriteLine(feetToInchesConverter.Convert(milesToFeetConverter.Convert(1))); // 63360
    }
}
