namespace IPv4Validator;

class Program
{
    static void Main(string[] args)
    {
        string[] ipv4Input = { "107.31.1.5", "255.0.0.255", "555..0.555", "255...255" };

        foreach (string ip in ipv4Input)
        {
            bool validLength = ValidateLength(ip);
            bool validZeroes = ValidateZeroes(ip);
            bool validRange = ValidateRange(ip);

            if (validLength && validZeroes && validRange)
            {
                Console.WriteLine($"{ip} is a valid IPv4 address");
            }
            else
            {
                Console.WriteLine($"{ip} is an invalid IPv4 address");
            }
        }
    }

    private static bool ValidateRange(string IPv4)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(IPv4);
        string[] address = IPv4.Split(".", StringSplitOptions.RemoveEmptyEntries);

        foreach (string number in address)
        {
            int value = int.Parse(number);
            if (value < 0 || value > 255)
            {
                return false;
            }
        }
        return true;
    }

    private static bool ValidateZeroes(string IPv4)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(IPv4);
        string[] address = IPv4.Split(".", StringSplitOptions.RemoveEmptyEntries);

        foreach (string number in address)
        {
            if (number.Length > 1 && number.StartsWith("0") == true)
            {
                return false;
            }
        }

        return true;
    }

    private static bool ValidateLength(string IPv4)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(IPv4);
        string[] address = IPv4.Split(".", StringSplitOptions.RemoveEmptyEntries);
        return address.Length == 4;
    }
}
