/*
** Write a program and ask the user to enter the width and height of an image.
** Then tell if the image is landscape or portrait.
**/
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter the height of the image: ");
        string? height = Console.ReadLine();
        Console.Write("Enter the weight of the image: ");
        string? weight = Console.ReadLine();
        bool parseHeight = int.TryParse(height, out int heightValue);
        bool parseWeight = int.TryParse(weight, out int weightValue);
        if (parseHeight && parseWeight)
        {
            if (heightValue > weightValue)
            {
                Console.WriteLine("Portrait image orientation");
            }
            else
            {
                Console.WriteLine("Landscape image orientation");
            }
        }
        else
        {
            Console.WriteLine("Height or Weight values were entered in incorrect format!");
        }
    }
}
