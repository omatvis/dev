using System;
using System.Collections.Generic;
using System.Text;


namespace GangOfFourDesignPatterns.Structural_Patterns;

/// <summary>
/// Allows incompatible interfaces to work together via an adapter.
/// </summary>

public interface ITarget { void Request(); }

public class Adaptee { public void SpecificRequest() => Console.WriteLine("Specific Request"); }

public class Adapter : ITarget
{
    private Adaptee _adaptee = new Adaptee();

    public void Request() => _adaptee.SpecificRequest();
}