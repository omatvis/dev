namespace Learn;

class Program
{
    static void Main(string[] args)
    {
        ArtificialSequence seq = new();
        foreach (int item in seq)
        {
          Console.WriteLine(item);    
        }        
    }
}


