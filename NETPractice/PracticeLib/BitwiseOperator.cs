using System;

namespace PracticeLib;

public static class BitwiseOperator
{
    public static string Complement(int a)
    {
        // Convert the result to a binary string
        return Convert.ToString(~a, 2);
    }

    public static string And(int a, int b)
    {
        // Convert the result to a binary string
        return Convert.ToString(a & b, 2);
    }

    public static string Or(int a, int b)
    {
        // Convert the result to a binary string
        return Convert.ToString(a | b, 2);
    }

    public static string Xor(int a, int b)
    {
        // Convert the result to a binary string
        return Convert.ToString(a ^ b, 2);
    }

    public static string ShiftLeft(int a, int b)
    {
        // Convert the result to a binary string
        return Convert.ToString(a << b, 2);
    }

    public static string ShiftRight(int a, int b)
    {
        // Convert the result to a binary string
        return Convert.ToString(a >> b, 2);
    }

    public static string UnsignedShiftRight(int a, int b)
    {
        // Convert the result to a binary string
        return Convert.ToString(a >>> b, 2);
    }
}
