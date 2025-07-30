namespace S1L7_HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog();
            dog.Live();
            Console.ReadKey();
        }
    }

    public class Animal { 
    
        public virtual void Live()
        {
            Console.WriteLine("Animal is living");
        }
    }

    public class Dog: Animal
    {
        public override void Live()
        {
            Console.WriteLine("Dog is living");
            base.Live();
        }
    }
}
