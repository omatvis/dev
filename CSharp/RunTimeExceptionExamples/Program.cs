namespace RunTimeExceptionExamples;

class Program
{
    static void Main(string[] args)
    {
        ArrayTypeMismatch();
        DivideByZero();
        Format();
        IndexOutOfRange();
        InvalidCast();
        NullReference();
        Overflow();
    }

    static void ArrayTypeMismatch()
    {
        string[] names = { "Dog", "Cat", "Fish" };
        Object[] objs = (Object[])names;

        Object obj = (Object)13;
        objs[2] = obj; // ArrayTypeMismatchException occurs
    }

    static void DivideByZero()
    {
        int number1 = 3000;
        int number2 = 0;
        Console.WriteLine(number1 / number2); // DivideByZeroException occurs
    }

    static void Format()
    {
        int valueEntered;
        string userValue = "two";
        valueEntered = int.Parse(userValue); // FormatException occurs
    }

    static void IndexOutOfRange()
    {
        int[] values1 = { 3, 6, 9, 12, 15, 18, 21 };
        int[] values2 = new int[6];

        values2[values1.Length - 1] = values1[values1.Length - 1]; // IndexOutOfRangeException occurs
    }

    static void InvalidCast()
    {
        object obj = "This is a string";
        int num = (int)obj;
    }

    static void NullReference()
    {
        int[] values = null;
        for (int i = 0; i <= 9; i++)
            values[i] = i * 2;

        string? lowCaseString = null;
        Console.WriteLine(lowCaseString.ToUpper());
    }

    static void Overflow()
    {
        decimal x = 400;
        byte i;

        i = (byte)x; // OverflowException occurs
        Console.WriteLine(i);
    }
}
