using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal interface IAnimals<T>
    {
        void Add(T name);
        void Remove(T name);

        T Peek(T name);
    }
}
