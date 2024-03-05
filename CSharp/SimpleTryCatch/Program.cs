namespace SimpleTryCatch;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Process1();
        }
        catch
        {
            Console.WriteLine("An exception has been caught");
        }
        Console.WriteLine("Exit program");
    }

    private static void Process1()
    {
        WriteMessage();
    }

    private static void WriteMessage()
    {
        double float1 = 3000.0;
        double float2 = 0.0;
        int number1 = 3000;
        int number2 = 0;
        Console.WriteLine(float1 / float2);
        Console.WriteLine(number1 / number2);
    }
}
