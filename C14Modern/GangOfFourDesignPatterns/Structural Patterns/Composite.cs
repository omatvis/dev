using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Structural_Patterns;

/// <summary>
/// Allows you to compose objects into tree structures to represent part-whole hierarchies.
/// </summary>
public abstract class Component
{
    public abstract void Operation();
}

public class Leaf : Component
{
    private string _name;
    public override void Operation() => Console.WriteLine($"Leaf {_name} Operation");
    public Leaf(string name) => _name = name;
}

public class Composite : Component
{
    private List<Component> _children = new List<Component>();

    public void Add(Component component) => _children.Add(component);
    public void Remove(Component component) => _children.Remove(component);

    public override void Operation()
    {
        Console.WriteLine("Composite Operation");
        foreach (var child in _children) child.Operation();
    }
}
