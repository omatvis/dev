using System;
using System.Collections;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        ConsecutiveSequence();
        DuplicatesInASequence();
        ValidateTimeInput();
        UsePascalCase();
        CountVowels();
    }

    /// <summary>
    /// Write a program and ask the user to enter a few numbers separated by a hyphen.
    /// Work out if the numbers are consecutive.
    /// For example, if the input is "5-6-7-8-9" or "20-19-18-17-16",
    /// display a message: "Consecutive"; otherwise, display "Not Consecutive".
    /// </summary>
    public static void ConsecutiveSequence()
    {
        Console.WriteLine("Enter a few numbers separated by a hyphen: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            return;
        }
        int[] numbers = input.Split('-').Select(n => int.Parse(n)).ToArray();
        if (numbers.Length == 1)
        {
            Console.WriteLine("Consecutive");
            return;
        }
        bool isConsecutive = true;
        for (int i = 1; i < numbers.Length; i++)
        {
            isConsecutive = isConsecutive && (numbers[i] > numbers[i - 1]);
            if (!isConsecutive)
                break;
        }
        Console.WriteLine((isConsecutive) ? "Consecutive" : "Not Consecutive");
    }

    /// <summary>
    /// Write a program and ask the user to enter a few numbers separated by a hyphen.
    /// If the user simply presses Enter, without supplying an input, exit immediately;
    /// otherwise, check to see if there are duplicates. If so, display "Duplicate" on the console.
    /// </summary>
    public static void DuplicatesInASequence()
    {
        Console.WriteLine("Enter a few numbers separated by a hyphen: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            return;
        }

        var duplicates = input
            .Split('-')
            .Select(n => int.Parse(n))
            .GroupBy(n => n)
            .Where(g => g.Count() > 1)
            .ToArray();
        foreach (var number in duplicates)
        {
            Console.WriteLine($"{number.Key}");
        }
    }

    /// <summary>
    /// Write a program and ask the user to enter a time value in the 24-hour time format (e.g. 19:00).
    /// A valid time should be between 00:00 and 23:59.
    /// If the time is valid, display "Ok"; otherwise, display "Invalid Time".
    /// If the user doesn't provide any values, consider it as invalid time.
    /// </summary>
    public static void ValidateTimeInput()
    {
        Console.Write("Enter a time value in the 24-hour time format: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid");
            return;
        }
        string[] timeStringParts = input.Split(':');
        if (timeStringParts.Length == 0 || timeStringParts.Length == 1)
        {
            Console.WriteLine("Invalid");
            return;
        }

        bool hoursConverted = int.TryParse(timeStringParts[0], out int hours);
        bool minutesConverted = int.TryParse(timeStringParts[0], out int minutes);
        if (
            hoursConverted
            && minutesConverted
            && hours >= 0
            && hours < 24
            && minutes >= 0
            && minutes < 60
        ) { 
            Console.WriteLine("OK");
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }

    /// <summary>
    /// Write a program and ask the user to enter a few words separated by a space.
    /// Use the words to create a variable name with PascalCase.
    /// For example, if the user types: "number of students",
    /// display "NumberOfStudents".
    /// Make sure that the program is not dependent on the input.
    /// So, if the user types "NUMBER OF STUDENTS", the program should still display "NumberOfStudents".
    /// </summary>
    public static void UsePascalCase() { 
        Console.Write("Enter a few words separated by a space: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) {
            Console.WriteLine("Exit");
            return;
        }
        string[] words = input.Split(' ');
        var pascalCaseWords = words.Select(x => x.Substring(0, 1).ToUpper() + x.ToLower().Remove(0, 1)).ToArray();
        Console.WriteLine($"Pascal case: {string.Join("", pascalCaseWords)}");
    }

    /// <summary>
    /// Write a program and ask the user to enter an English word.
    /// Count the number of vowels (a, e, o, u, i) in the word.
    /// So, if the user enters "inadequate",
    /// the program should display 6 on the console.
    /// </summary>
    public static void CountVowels() { 
        Console.WriteLine("Enter an English word: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) {
            return;
        }
        input = input.ToLower();
        char[] vowels = ['a', 'e', 'o', 'u', 'i'];
        int countVowels = 0;
        foreach (var character in input)
        {
            countVowels += (Array.IndexOf(vowels, character) > -1) ? 1 : 0;
        }
        Console.WriteLine($"Vowels: {countVowels}");
    }
}
