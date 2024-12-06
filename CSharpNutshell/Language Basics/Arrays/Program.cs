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
    }
}