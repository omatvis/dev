using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Structural_Patterns;

/// <summary>
/// Provides a surrogate or placeholder for another object to control access to it.
/// </summary>
public interface ISubject { void Request(); }

public class RealSubject : ISubject { public void Request() => Console.WriteLine("Real Request"); }

public class Proxy : ISubject
{
    private RealSubject? _realSubject;

    public void Request()
    {
        if (_realSubject == null) _realSubject = new RealSubject();
        _realSubject.Request();
    }
}
