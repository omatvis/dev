using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Structural_Patterns;

/// <summary>
/// Provides a unified interface to a set of interfaces in a subsystem. Facade defines a higher-level interface that makes the subsystem easier to use.
/// </summary>
public class SubsystemA { public void MethodA() => Console.WriteLine("Subsystem A"); }
public class SubsystemB { public void MethodB() => Console.WriteLine("Subsystem B"); }

public class Facade
{
    private SubsystemA _a = new SubsystemA();
    private SubsystemB _b = new SubsystemB();

    public void Operation()
    {
        _a.MethodA();
        _b.MethodB();
    }
}