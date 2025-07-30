using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Animals<T> : IAnimals<T>
    {
        List<T> _list = new List<T>();

        public void Add(T name)
        {
            _list.Add(name);
        }

        public T Peek(T name)
        {
            if (_list.Any(x => x == null || !x.Equals(name)))
            {
                throw new ArgumentException("Name not found in the list.");
            }
            return _list.First(x => x != null && x.Equals(name));
        }

        public void Remove(T name)
        {
            _list.Remove(name);
        }
    }
}
