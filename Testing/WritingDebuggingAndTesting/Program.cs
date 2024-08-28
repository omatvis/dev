partial class Program
{
    private static void Main(string[] args)
    {
        TimesTable(7, 20);
        WriteLine($"You must pay {CalculateTax(amount: 149, twoLetterregionCode: "FR")} in tax.");
    }
}
