using System;
using System.IO;
using System.Linq;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string createdTempFile = CreateATextFile("This is a text content of the file.");
        NumberOfWordsInAFile(createdTempFile);
        LongestWordInAFile(createdTempFile);
        DeleteATextFile(createdTempFile);
    }

    private static string CreateATextFile(string aText)
    {
        const string tempFileName = "test.txt";
        string tempFileNamePath = Path.Combine(Path.GetTempPath(), tempFileName);

        FileInfo textFile = new(tempFileNamePath);

        using FileStream fs = textFile.OpenWrite();
        ReadOnlySpan<byte> text = new UTF8Encoding(true).GetBytes(aText);
        fs.Write(text);

        return Path.Combine(Path.GetTempPath(), tempFileName);
    }

    private static void DeleteATextFile(string path)
    {
        File.Delete(path);
    }

    /// <summary>
    /// Write a program that reads a text file and displays the number of words.
    /// </summary>

    public static void NumberOfWordsInAFile(string filePath)
    {
        string content = File.ReadAllText(filePath, Encoding.UTF8);
        string[] strings = content.Split(' ');
        Console.WriteLine("Words in the text: " + strings.Length);
    }

    /// <summary>
    /// Write a program that reads a text file and displays the longest word in the file.
    /// </summary>

    public static void LongestWordInAFile(string filePath)
    {
        string content = File.ReadAllText(filePath, Encoding.UTF8);
        string[] strings = content.Split(' ');
        int maxLength = strings.Select(x => x.Trim()).Max(r => r.Length);
        Console.WriteLine("Longest word in the text: " + maxLength);
    }
}
