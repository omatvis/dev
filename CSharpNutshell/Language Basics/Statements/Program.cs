internal class Program
{
    private static void Main(string[] args)
    {
        // if statement
        if (2 + 2 == 5)
            Console.WriteLine("Does not compute");
        else if (2 + 2 == 4)
            Console.WriteLine("Computes"); // Computes
        TellMeWhatICanDo(90);
        ShowCard(13);
        TellMeTheType(12);
        TellMeTheType("hello");
        TellMeTheType(true);

        int cardNumber = 12;
        string suite = "spades";
        string cardName = (cardNumber, suite) switch
        {
            (12, "spades") => "King of spades",
            (13, "clubs") => "King of clubs",
            _ => "Full",
        };
        Console.WriteLine(cardName);

        int i = 0;
        while (i < 3)
        {
            Console.Write(i);
            i++;
        }

        i = 0;
        do
        {
            Console.WriteLine(i);
            i++;
        } while (i < 3);

        for (int j = 0, prevFib = 1, curFib = 1; j < 10; j++)
        {
            Console.WriteLine(prevFib);
            int newFib = prevFib + curFib;
            prevFib = curFib;
            curFib = newFib;
        }

        foreach (char c in "beer") // c is the iteration variable
            Console.WriteLine(c);
    }

    static void TellMeWhatICanDo(int age)
    {
        if (age >= 35)
            Console.WriteLine("You can be president!");
        else if (age >= 21)
            Console.WriteLine("You can drink!");
        else if (age >= 18)
            Console.WriteLine("You can vote!");
        else
            Console.WriteLine("You can wait!");
    }

    static void ShowCard(int cardNumber)
    {
        switch (cardNumber)
        {
            case 13:
                Console.WriteLine("King");
                break;
            case 12:
                Console.WriteLine("Queen");
                break;
            case 11:
                Console.WriteLine("Jack");
                break;
            case -1: // Joker is -1
                goto case 12; // In this game joker counts as queen
            default: // Executes for any other cardNumber
                Console.WriteLine(cardNumber);
                break;
        }
    }

    static void TellMeTheType(object x) // object allows any type.
    {
        switch (x)
        {
            case int i:
                Console.WriteLine("It's an int!");
                Console.WriteLine($"The square of {i} is {i * i}");
                break;
            case string s:
                Console.WriteLine("It's a string");
                Console.WriteLine($"The length of {s} is {s.Length}");
                break;
            case DateTime:
                Console.WriteLine("It's a DateTime");
                break;
            default:
                Console.WriteLine("I don't know what x is");
                break;
        }
    }
}
