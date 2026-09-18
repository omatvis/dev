using System.Globalization;
using System.Runtime.CompilerServices;

namespace Extensions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            IEnumerable<int> greaterThen = ((IEnumerable<int>)numbers).GreaterThan(3);         
            Console.WriteLine(string.Join(", ", greaterThen));
            if (greaterThen.HasItems)
            {
                Console.WriteLine("All greater than 3: " + greaterThen.AllGreaterThan(3));
            }
        }

    }

    public static class IEnumarableExtensions {
        public static IEnumerable<int> GreaterThan(this IEnumerable<int> source, int value)
        {
            return source.Where(x => x > value);
        }
    }

    public static class IEnumerableModernExtentions { 
    
        extension(IEnumerable<int> source)
        {
            public bool AllGreaterThan(int value)
            {
                return source.All(x => x > value);
            }

            public bool HasItems => source.Any();
        }
    }
}
