using System;
using System.Collections.Generic;
using System.Text;

namespace InOutGeneric
{
    public interface IGeneralAnimalPrint<in T1, out T2>
    {
        T2 WriteLine(T1 animal);        
    }

    internal class GeneralAnimalPrintImpl : IGeneralAnimalPrint<Animal, Animal>
    {
        public Animal WriteLine(Animal animal)
        {
            Console.WriteLine($"Name: {animal.Name}");
            return animal;
        }
    }
}
