using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        FacebookLikes();
        ReverseName();
        FiveUniqueNumbers();
        EndLessUniqueNumbers();
        ThreeSmallestNumbers();
    }

    /// <summary>
    /// When you post a message on Facebook, depending on the number of people who like your post,
    /// Facebook displays different information.
    /// If no one likes your post, it doesn't display anything.
    /// If only one person likes your post, it displays: [Friend's Name] likes your post.
    /// If two people like your post, it displays: [Friend 1] and [Friend 2] like your post.
    /// If more than two people like your post, it displays: [Friend 1], [Friend 2]
    /// and [Number of Other People] others like your post.
    /// Write a program and continuously ask the user to enter different names,
    /// until the user presses Enter (without supplying a name).
    /// Depending on the number of names provided, display a message based on the above pattern.
    /// </summary>
    static void FacebookLikes()
    {
        var enteredListNames = new List<string>();
        Console.WriteLine("Supply names until you press Enter: ");
        while (true)
        {
            var input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input))
            {
                break;
            }
            enteredListNames.Add(input);
        }
        switch (enteredListNames.Count)
        {
            case 0:
                break;
            case 1:
                Console.WriteLine($"{enteredListNames[0]} likes your post.");
                break;
            case 2:
                Console.WriteLine(
                    $"{enteredListNames[0]} and {enteredListNames[1]} like your post."
                );
                break;
            case > 2:
                Console.WriteLine(
                    $"{enteredListNames[0]}, {enteredListNames[1]} and {enteredListNames.Count - 2} others like your post."
                );
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Write a program and ask the user to enter their name.
    /// Use an array to reverse the name and then store the result in a new string.
    /// Display the reversed name on the console.
    /// </summary>
    static void ReverseName()
    {
        Console.Write("Enter your name: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Name cannot be an empty string");
            return;
        }
        char[] name = input.ToCharArray();
        Array.Reverse(name);
        Console.WriteLine(string.Join("", name));
    }

    /// <summary>
    /// Write a program and ask the user to enter 5 numbers.
    /// If a number has been previously entered, display an error message and ask the user to re-try.
    /// Once the user successfully enters 5 unique numbers, sort them and display the result on the console.
    /// </summary>
    static void FiveUniqueNumbers()
    {
        int?[] numbers = [null, null, null, null, null];
        int index = 0;
        while (index < 5)
        {
            Console.WriteLine("Enter a number: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) {
                Console.WriteLine("Input cannot be empty!");
                continue;
            }
            int number = int.Parse(input);
            bool numberExist = Array.IndexOf(numbers, number) > -1;
            if (!numberExist) {
                numbers[index] = number;
                ++index;
            }
        }
        Array.Sort(numbers);
        Console.WriteLine("");
        foreach (int? number in numbers)
        {
            Console.WriteLine(number);    
        }
    }

    /// <summary>
    /// Write a program and ask the user to continuously enter a number or type "Quit" to exit.
    /// The list of numbers may include duplicates. Display the unique numbers that the user has entered.
    /// </summary>
    static void EndLessUniqueNumbers() { 
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter numbers or type Quit.");
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) {
                continue;
            }
            if (string.Equals(input, "Quit")) {
                break;
            }
            int number = int.Parse(input);
            numbers.Add(number);
        }

        Console.WriteLine("");
        while (numbers.Count > 0)
        {
            int value = numbers[0];
            numbers.Remove(value);
            if (numbers.IndexOf(value) == -1) {
                Console.WriteLine(value);
            } 
        }
    }

    /// <summary>
    /// Write a program and ask the user to supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10).
    /// If the list is empty or includes less than 5 numbers,
    /// display "Invalid List" and ask the user to re-try;
    /// otherwise, display the 3 smallest numbers in the list.
    /// </summary>
    static void ThreeSmallestNumbers() {
        Console.Write("Supply a list of comma separated numbers: ");
        while (true) {
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) {
                Console.WriteLine("Sequence cannot be empty!");
            }
            string[] strs = input!.Split(",");

            if (strs.Length < 5) {
                Console.WriteLine("Invalid List! Re-try please.");
            }
            int[] numbers = new int[strs.Length];
            numbers = Array.ConvertAll<string, int>(strs, (string s) => int.Parse(s));
            Array.Sort(numbers);
            Console.WriteLine("");
            int prevNumber = int.MinValue;
            int counter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                ++counter;
                if (counter > 3) break;
                if (prevNumber == numbers[i]) {
                    --counter;
                    continue;
                }
                prevNumber = numbers[i];
                Console.WriteLine(numbers[i]);
            }
            break;
        }
    }
}
