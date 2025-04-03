using System;
using System.Collections.Generic;
namespace Packt.Shared;

public class Person
{
    #region Fields: Data or state for this person.
    public string? Name; // ? means it can be null - actual type of name System.Nullable<string>.
    public DateTimeOffset Born;
    #endregion
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    private List<Person> Children = new();
    public Person AddChild(Person child)
    {
        Children.Add(child);
        return this;
    }

    public Person RemoveChild(Person child) {
        if (Children.Remove(child)) {
            return child;
        }
        else
        {
            throw new ArgumentException($"{child.Name} is not a child of {Name}");
        }
    }

    public int ChildrenCount => Children.Count;
    public Person this[int index]
    {
        get => Children[index];
    }
}
