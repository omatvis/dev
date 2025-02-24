using System;

namespace PracticeLib
{
    namespace Generics
    {
        public class Stack<T>
        {
            int position;
            readonly T[] data = new T[1000];

            public void Push(T obj) => data[position++] = obj;

            public T Pop() => data[--position];

            public T this[int index] => data[index];
        }

        public class Utils<T>
        {
            public static void Swap(ref T a, ref T b)
            {
                (b, a) = (a, b);
            }
        }
    }

    namespace VarianceType
    {
        public class Animal { }

        public class Bear : Animal { }

        public class Camel : Animal { }
    }
}
