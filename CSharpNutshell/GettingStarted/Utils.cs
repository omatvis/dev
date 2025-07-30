using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQQueries
{
    internal static class Utils
    {
        public static IEnumerable<T> FilterWhere<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            ArgumentNullException.ThrowIfNull(predicate, nameof(predicate));
            return source.Where<T>(predicate);
        }

        public static IEnumerable<string> FluentFilterWhereByName<T>(IEnumerable<string> source, string containedText)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            return from n in source where n.Contains(containedText) select n;
        }

        public static void Print<T>(IEnumerable<T> source)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            foreach (T item in source)
            {
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<string> FilterAndTransform(IEnumerable<string> source, string containedText)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            return source
                .Where(s => s.Contains(containedText))
                .OrderBy(s => s.Length)
                .Select(s => s.ToUpper());
        }

        public static IEnumerable<string> ClosureAndDefferedLINQExecutionProblem(IEnumerable<string> source, string predicator)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            for (int i = 0; i < predicator.Length; ++i)
            {
                source = source.Where(s => !s.Contains(predicator[i]));                
            }
            return source;
        }

        public static IEnumerable<string> ClosureAndDefferedLINQExecutionProblemFix(IEnumerable<string> source, string predicator)
        {
            ArgumentNullException.ThrowIfNull(source, nameof(source));
            for (int i = 0; i < predicator.Length; ++i)
            {                
                int currentIndex = i;
                source = source.Where(s => !s.Contains(predicator[currentIndex]));
            }
            return source;
        }
    }
}
