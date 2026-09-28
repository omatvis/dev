using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Behavioral_Patterns;

/// <summary>
/// The Iterator pattern is a behavioral design pattern that provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation. It allows you to traverse a collection of objects without needing to know the details of how the collection is implemented. The pattern is useful when you want to provide a standard way to iterate over different types of collections, such as lists, arrays, or custom data structures.
/// </summary>
public class Aggregate : IEnumerable<string>
{
    private List<string> _items = new List<string> { "Item1", "Item2" };

    public IEnumerator<string> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
    