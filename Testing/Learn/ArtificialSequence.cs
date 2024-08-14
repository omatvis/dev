using System.Collections;

namespace Learn;

class ArtificialSequence : IEnumerable, IEnumerator
{
    private const int _maximum = 100;
    private int _current;

    public object Current
    {
        get => _current;
    }
    public ArtificialSequence () {
        _current = 0;
    }

    public IEnumerator GetEnumerator()
    {
        return this;
    }

    public bool MoveNext()
    {
        return ++_current < _maximum;
    }

    public void Reset()
    {
        _current = 0;
    }
}
