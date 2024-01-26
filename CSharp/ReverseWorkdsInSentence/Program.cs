namespace ReverseWorkdsInSentence;

using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        string pangram = "The quick brown fox jumps over the lazy dog";        
        string[] words = pangram.Split(' ');
        foreach (string word in words)
        {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            Console.Write(new string(chars) + " ");
        }
    }
}
