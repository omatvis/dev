using System.Collections;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, object> dictionary = new Dictionary<int, object>();
            dictionary.Add(1, new { Name = "John" , Surname = "Doe" });
            dictionary.Add(2, new { Name = "John", Surname = "Doe" });
            dictionary.Add(3, new { Name = "John", Surname = "Doe" });
            dictionary.Add(4, new { Name = "John", Surname = "Doe" });
            dictionary.Add(5, new { Name = "John", Surname = "Doe" });

            foreach (KeyValuePair<int, object> item in dictionary)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value.GetType().GetProperty("Name")?.GetValue(item.Value));
            }


        }
    }

}
