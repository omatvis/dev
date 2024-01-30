namespace ManipulationWithString;

using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        IndexOfAndSubstring();
        IndexOfAnyAndLastIndexOf();
        RemoveAndReplace();
        ExtractReplaceAndRemove();
    }

    private static void ExtractReplaceAndRemove()
    {
        const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

        string quantity = "";
        string output = "";

        // Your work here
        const string openingSpan = "<span>";
        const string closingSpan= "</span>";
        quantity = input.Substring(input.LastIndexOf(openingSpan) + openingSpan.Length, 
                                   input.LastIndexOf(closingSpan) - input.LastIndexOf(openingSpan) - openingSpan.Length);

        const string openingDiv = "<div>";
        const string closingDiv = "</div>";
        output = input.Remove(input.LastIndexOf(openingDiv), openingDiv.Length);
        output = output.Remove(output.LastIndexOf(closingDiv), closingDiv.Length);
        output = output.Replace("&trade", "&reg");
        Console.WriteLine($"Quantity: {quantity:N}");
        Console.WriteLine($"Output: {output}");
    }

    private static void IndexOfAndSubstring()
    {
        string message = "What is the value <span>between the tags</span>?";

        const string openSpan = "<span>";
        const string closeSpan = "</span>";

        int openingPosition = message.IndexOf(openSpan);
        int closingPosition = message.IndexOf(closeSpan);

        openingPosition += openSpan.Length;
        int length = closingPosition - openingPosition;
        Console.WriteLine(message.Substring(openingPosition, length));
    }

    private static void IndexOfAnyAndLastIndexOf()
    {
        string message =
            "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";

        // The IndexOfAny() helper method requires a char array of characters.
        // You want to look for:

        char[] openSymbols = ['[', '{', '('];

        // You'll use a slightly different technique for iterating through
        // the characters in the string. This time, use the closing
        // position of the previous iteration as the starting index for the
        //next open symbol. So, you need to initialize the closingPosition
        // variable to zero:

        int closingPosition = 0;

        while (true)
        {
            int openingPosition = message.IndexOfAny(openSymbols, closingPosition);

            if (openingPosition == -1)
                break;

            string currentSymbol = message.Substring(openingPosition, 1);

            // Now  find the matching closing symbol
            char matchingSymbol = ' ';

            switch (currentSymbol)
            {
                case "[":
                    matchingSymbol = ']';
                    break;
                case "{":
                    matchingSymbol = '}';
                    break;
                case "(":
                    matchingSymbol = ')';
                    break;
            }

            // To find the closingPosition, use an overload of the IndexOf method to specify
            // that the search for the matchingSymbol should start at the openingPosition in the string.

            openingPosition += 1;
            closingPosition = message.IndexOf(matchingSymbol, openingPosition);

            // Finally, use the techniques you've already learned to display the sub-string:

            int length = closingPosition - openingPosition;
            Console.WriteLine(message.Substring(openingPosition, length));
        }
    }

    private static void RemoveAndReplace()
    {
        string data = "12345John Smith          5000  3  ";
        string updatedData = data.Remove(5, 20);
        Console.WriteLine(updatedData);
        string message = "This--is--ex-amp-le--da-ta";
        message = message.Replace("--", " ");
        message = message.Replace("-", "");
        Console.WriteLine(message);
    }
}
