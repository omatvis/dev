using System.Linq.Expressions;

namespace ExceptionExercise;

class Program
{
    static void Main(string[] args)
    {
        string[][] userEnteredValues = new string[][]
        {
            new string[] { "1", "2", "3" },
            new string[] { "1", "two", "3" },
            new string[] { "0", "1", "2" }
        };

        Workflow1(userEnteredValues);

        static void Workflow1(string[][] userEnteredValues)
        {

            foreach (string[] userEntries in userEnteredValues)
            {
                try
                {
                    Process1(userEntries);
                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine("'Process1' encountered an issue, process aborted.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("'Process1' encountered an issue, process aborted.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        static void Process1(String[] userEntries)
        {
            int valueEntered;
            int calculatedValue;
            foreach (string userValue in userEntries)
            {
                try
                {
                    valueEntered = int.Parse(userValue);
                    checked
                    {
                        calculatedValue = 4 / valueEntered;
                    }
                    Console.WriteLine($"User Value: {valueEntered}, Calculated Value: {calculatedValue}");
                }
                catch (System.FormatException ex)
                {
                    throw new FormatException(
                        $"Invalid data. User input values must be valid integers. User value: {userValue}",
                        ex
                    );
                }
                catch (System.DivideByZeroException ex)
                {
                    throw new DivideByZeroException(
                        $"Invalid data. User input values must be non-zero values. User value: {userValue}",
                        ex
                    );
                }
            }
        }
    }
}
