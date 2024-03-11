using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace EnumeratorExecise;

class IntegralEnumerable : IEnumerable
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)new IntegralEnumerator();
    }
}

class IntegralEnumerator : IEnumerator
{
    int _number = 0;
    public object Current => _number;

    public bool MoveNext()
    {
        _number += 2;
        return _number < 100;
    }

    public void Reset()
    {
        _number = 0;
    }
}
