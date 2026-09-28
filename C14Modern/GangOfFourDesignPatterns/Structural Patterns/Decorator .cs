using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Structural_Patterns;

/// <summary>
/// Allows behavior to be added to an individual object, dynamically, without affecting the behavior of other objects from the same class.
/// </summary>

public interface IComponent { void Operation(); }

public class ConcreteComponent : IComponent { public void Operation() => Console.WriteLine("Concrete Operation"); }

public abstract class Decorator : IComponent
{
    protected IComponent _component;

    protected Decorator(IComponent component) => _component = component;

    public abstract void Operation();
}

public class ConcreteDecorator : Decorator
{
    public ConcreteDecorator(IComponent component) : base(component) { }

    public override void Operation()
    {
        _component.Operation();
        Console.WriteLine("Decorator Added");
    }
}
