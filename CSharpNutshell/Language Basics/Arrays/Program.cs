using System;
internal class Program
{
    private static void Main(string[] args)
    {
        char[] vowels = ['a', 'e', 'i', 'o', 'u'];
        Console.WriteLine(vowels[1]);
        for (int i = 0; i < vowels.Length; i++)
        {
            Console.WriteLine($"vowels[{i}] = {vowels[i]}");
        }
        char lastElement = vowels[^1];
        char secondToLastElement = vowels[^2];
        Console.WriteLine($"Last: {lastElement}, Second to last {secondToLastElement}");

        Index first = 0;
        Index last = ^1;
        System.Console.WriteLine($"First: {vowels[first]}, Last {vowels[last]}");

        char[] firstTwo = vowels [..2]; // 'a', 'e'
        char[] lastThree = vowels [2..]; // 'i', 'o', 'u'
        char[] middleOne = vowels [2..3]; // 'i'
        char[] lastTwo = vowels [^2..]; // 'o', 'u'
        Range firstTwoRange = 0..2;
        char[] firstTwoElement = vowels [firstTwoRange]; // 'a', 'e'

        // Rectangular array
        int[,] matrix = new int[3, 3] {
            { 0, 1, 2},
            {3,4,5},
            {6,7,8}
        };
        for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write($" {matrix[i, j]} ");
            if (j == matrix.GetLength(1) - 1) {
                System.Console.WriteLine();
            }    
        }

        // Jagged arrays
        int[][][] cube = new int[3][][];
        for (int i = 0; i < cube.Length; i++)
        {
            cube[i] = new int[3][];
            for (int j = 0; j < cube[i].Length; j++)
            {
                cube[i][j] = new int[3];
                for (int k = 0; k < cube[i][j].Length; k++)
                {
                    cube[i][j][k] = i + j + k;
                    System.Console.WriteLine($" {cube[i][j][k]} ");
                }
            }
        }
    }
}