namespace SwitchArrayPatternMatching;

class Program
{
    static void Main(string[] args)
    {
        string[] words = ["word1", "word2"];
        switch (words)
        {
            case ["word1", "word2"]:
                Console.WriteLine("Array with exact 2 elements and the same values");
                break;
/*             case[..]:
                Console.WriteLine("Array with any elements");
                break; */
/*             case []:
                Console.WriteLine("Empty array");
                break; */
            default:
                Console.WriteLine("Default section");
                break;     
        } 
    }
}
