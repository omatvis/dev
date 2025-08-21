using System;
using System.Collections.Generic;
using EnumerationAndIterators;
internal class Program
{
    private static void Main(string[] args)
    {
        foreach (int fib in Iterators.EvenNumbersOnly(Iterators.Fibs(6)))
            Console.Write(fib + " ");

        SequenceOfEntities entities = new SequenceOfEntities();
        entities.Add(new Entity(1, "Entity1"));
        entities.Add(new Entity(2, "Entity2"));
        entities.Add(new Entity(3, "Entity3"));

        Console.WriteLine();
        foreach (Entity entity in entities)
        {
            Console.WriteLine($"ID: {entity.Id}, Name: {entity.Name}");
        }
        Console.WriteLine("Total Entities: " + entities.Count);
        Console.ReadKey();
    }
}
