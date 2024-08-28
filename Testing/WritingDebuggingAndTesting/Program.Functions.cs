partial class Program
{
    static void TimesTable(byte number, byte size = 12) {
        WriteLine($"This is the {number} times table with {size} rows:");
        for (int i = 1; i <= size; i++)
        {
            WriteLine($"{i} x {number} = {i*number}");
        }
    }

    static decimal CalculateTax(decimal amount, string twoLetterregionCode) {
        decimal rate = twoLetterregionCode switch
        {
            "CH" => 0.08M,
            "DK" or "NO" => 0.25M,
            "GB" or "FR" => 0.2M,
            "HU" => 0.27M,
            "OR" or "AK" or "MT" => 0.0M,
            "ND" or "WE" or "ME" or "VA" => 0.05M,
            "CA" => 0.0825M, 
            _ => 0
        };
        return amount * rate;
    }
}
