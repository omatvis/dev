using System.Collections;
using System.Reflection.Metadata.Ecma335;

public class ArtificialStringOfChars(params char[] chars) : IEnumerable, IEnumerator
{
    private int index = -1;

    //private readonly char[] chars = chars;
    public int Length
    {
        get { return chars.Length; }
    }

    public object Current => chars[index];

    public char this[int index]
    {
        get { return chars[index]; }
    }

    public char[] this[Range range]
    {
        get { return chars[range]; }
    }

    public char this[Index index]
    {
        get { return chars[index]; }
    }

    public bool MoveNext()
    {
        index++;

        return index < chars.Length;
    }

    public void Reset()
    {
        index = 0;
    }

    public void Dispose() { }

    public ArtificialStringOfChars GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }
}
