namespace BigIntegerCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the positive integer value: ");
            string? aNumber = Console.ReadLine();
            
            if (string.IsNullOrEmpty(aNumber))
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            
            BigInt binaryConverter = new BigInt(aNumber);
            binaryConverter.Parse();
            Console.WriteLine(binaryConverter.ToString());

        }
    }
}
