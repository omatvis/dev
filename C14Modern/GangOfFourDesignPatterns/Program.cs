namespace GangOfFourDesignPatterns
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Singelton singleton = Singelton.Instance;
            Console.WriteLine($"nameOf: {nameof(singleton)} \ntype: {typeof(Singelton)} \nusefull call: {singleton.SomeUsefulMethod()}" );
            Console.WriteLine();
        }
    }
}
