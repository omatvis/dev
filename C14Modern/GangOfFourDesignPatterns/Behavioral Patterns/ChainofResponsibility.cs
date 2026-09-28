using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Behavioral_Patterns;

/// <summary>
/// Defines a chain of handlers that can process requests. 
/// Each handler can either handle the request or pass it to the next handler in the chain.
/// </summary>
public abstract class Handler
{
    protected Handler? _next;

    public void SetNext(Handler next) => _next = next;

    public abstract void HandleRequest(int request);
}

public class ConcreteHandlerA : Handler
{
    public override void HandleRequest(int request)
    {
        if (request < 10) Console.WriteLine("Handled by A");
        else _next?.HandleRequest(request);
    }
}

public class ConcreteHandlerB : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10) Console.WriteLine("Handled by B");
        else _next?.HandleRequest(request);
    }
}
