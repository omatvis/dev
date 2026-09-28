using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Creational_Pattern;

/// <summary>
/// Provides an interface for creating objects in a parent class, 
/// but lets child classes decide which class to instantiate.
/// </summary>

public abstract class Product { }

public class ConcreteProductA : Product { }
public class ConcreteProductB : Product { }

public abstract class Creator
{
    public abstract Product FactoryMethod();
}

public class ConcreteCreatorA : Creator
{
    public override Product FactoryMethod() => new ConcreteProductA();
}

public class ConcreteCreatorB : Creator
{
    public override Product FactoryMethod() => new ConcreteProductB();
}