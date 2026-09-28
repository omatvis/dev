using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Structural_Patterns;

/// <summary>
/// Decouples an abstraction from its implementation so that the two can vary independently.
/// </summary>
public interface IImplementor { void OperationImpl(); }

public class ConcreteImplementorA : IImplementor { public void OperationImpl() => Console.WriteLine("Impl A"); }
public class ConcreteImplementorB : IImplementor { public void OperationImpl() => Console.WriteLine("Impl B"); }

public abstract class Abstraction
{
    protected IImplementor _implementor;

    protected Abstraction(IImplementor implementor) => _implementor = implementor;

    public abstract void Operation();
}

public class RefinedAbstraction : Abstraction
{
    public RefinedAbstraction(IImplementor implementor) : base(implementor) { }

    public override void Operation() => _implementor.OperationImpl();
}

