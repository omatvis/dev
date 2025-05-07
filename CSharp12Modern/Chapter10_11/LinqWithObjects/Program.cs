namespace LinqWithObjects
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            // A string array is a sequence that implements IEnumerable<string>.
            string[] names = ["Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed"];

            //DeferredExecution(names);
            //FilteringUsingWhere(names);
            //FilteringByType();
            WorkingWithSets();
        }
    }
}
