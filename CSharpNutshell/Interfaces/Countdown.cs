using System;
using System.Collections.Generic;
using System.Collections;

namespace Interfaces
{

    public class Countdown : IEnumerable, IEnumerator
    {
        private int _current = 11;
        public object Current => _current;
        public bool MoveNext() => --_current > 0;
        public void Reset() => _current = 11;
        public IEnumerator GetEnumerator() => this;
    }

}
