using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Behavioral_Patterns;

/// <summary>
/// The State Design Pattern is a behavioral design pattern that allows an object to alter its behavior when its internal state changes
/// </summary>

public interface IContextState { void Handle(ContextState context); }

public class ConcreteStateA : IContextState
{
    public void Handle(ContextState context)
    {
        Console.WriteLine(("State A handles request and transitions to State B."));
        context.State = new ConcreteStateB();
    }
}

public class ConcreteStateB : IContextState
{
    public void Handle(ContextState context)
    {
        Console.WriteLine("State B handles request and transitions to State A.");
        context.State = new ConcreteStateA();
    }
}

public class ContextState
{
    public IContextState State { get; set; } = null!;

    public ContextState(IContextState state) => TransitionTo(state);
    public void TransitionTo(IContextState state)
    {
        Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
        State = state;
    }
    public void Request() => State.Handle(this);
}
