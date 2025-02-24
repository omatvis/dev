using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using System.Text;

namespace PracticeLib;

public static class ParametersInMethodTypes
{
    // Passing arguments by value
    public static int IncrementByValue(int x)
    {
        return x + 1;
    }

    // Passing arguments by reference - reference it self is copied. message = null has no efect on instance of StringBuilder
    public static void AddBye(StringBuilder message)
    {
        ArgumentNullException.ThrowIfNull(message);
        message.Append(" Bye!");
        message = null!;
    }

    // Passing arguments by reference
    public static int IncrementByReference(ref int p)
    {
        p++;
        return p;
    }
}
