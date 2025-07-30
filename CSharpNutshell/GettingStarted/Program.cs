namespace LINQQueries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filteredNames = Utils.FilterWhere<string>(["Tom", "Dick", "Harry"], name => name.Length >= 4);
            Utils.Print(filteredNames);
            Console.WriteLine("");

            filteredNames = Utils.FilterWhere<string>(["Tom", "Dick", "Harry"], (name) => name.Contains('a'));
            Utils.Print(filteredNames);
            Console.WriteLine("");

            filteredNames = Utils.FluentFilterWhereByName<string>(["Tom", "Dick", "Harry"], "a");
            Utils.Print(filteredNames);
            Console.WriteLine("");

            filteredNames = Utils.FilterAndTransform(["Tom", "Dick", "Harry", "Mary", "Jay"], "a");
            Utils.Print(filteredNames);
            Console.WriteLine("");

            var query = "Not want you might expect".AsEnumerable<char>();
            string vowels = "aeiou";

            filteredNames = Utils.ClosureAndDefferedLINQExecutionProblem(query.Select(n => Char.ToString(n)), vowels);
            try
            {
                Utils.Print(filteredNames);
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine("Exception caught: " + e.Message);
            }
            filteredNames = Utils.ClosureAndDefferedLINQExecutionProblemFix(query.Select(n => Char.ToString(n)), vowels);
            Utils.Print(filteredNames);
            Console.WriteLine(query);

            Console.ReadKey();
        }
    };
}
