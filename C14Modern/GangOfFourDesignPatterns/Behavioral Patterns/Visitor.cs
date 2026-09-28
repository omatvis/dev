using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Behavioral_Patterns;

/// <summary>
/// The Visitor Design Pattern is a behavioral design pattern that allows you to separate algorithms from the objects on which they operate. 
/// It lets you define a new operation without changing the classes of the elements on which it operates.
/// </summary>
/// 
public interface IVisitor { void Visit(ElementA element); void Visit(ElementB element); }

public abstract class Element { public abstract void Accept(IVisitor visitor); }

public class ElementA : Element { public override void Accept(IVisitor visitor) => visitor.Visit(this); }
public class ElementB : Element { public override void Accept(IVisitor visitor) => visitor.Visit(this); }

public class ConcreteVisitor : IVisitor
{
    public void Visit(ElementA element) => Console.WriteLine("Visited A");
    public void Visit(ElementB element) => Console.WriteLine("Visited B");
}

public class ObjectStructure
{
    private List<Element> _elements = new List<Element>();

    public void Add(Element element) => _elements.Add(element);

    public void Accept(IVisitor visitor)
    {
        foreach (var element in _elements) element.Accept(visitor);
    }
}