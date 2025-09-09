using System.Text.RegularExpressions;

namespace S12L241_Regex_email
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exercise = new Exercise();
            exercise.ExtractPatterns("Contact us at support@example.com or sales@example.org.");
            Console.ReadKey();
        }
    }

    public class Exercise
    {
        public void ExtractPatterns(string input)
        {
            Regex regex = new Regex(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }

}