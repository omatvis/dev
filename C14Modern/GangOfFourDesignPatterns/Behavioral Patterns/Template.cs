using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Behavioral_Patterns;

/// <summary>
/// The Template Design Pattern is a behavioral design pattern that defines the program skeleton of an algorithm in a method, called a template method, which defers some steps to subclasses. It lets one redefine certain steps of an algorithm without changing the algorithm's structure.
/// </summary>
public abstract class AbstractClass
{
    public void TemplateMethod()
    {
        PrimitiveOperation1();
        PrimitiveOperation2();
    }

    protected abstract void PrimitiveOperation1();
    protected abstract void PrimitiveOperation2();
}

public class ConcreteClass : AbstractClass
{
    protected override void PrimitiveOperation1() => Console.WriteLine("Op1");
    protected override void PrimitiveOperation2() => Console.WriteLine("Op2");
}
