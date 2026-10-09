using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Behavioral_Patterns;

/// <summary>
/// The Memento Design Pattern is a behavioral design pattern that allows an object to capture its internal state and 
/// save it externally 
/// so that it can be restored later without violating encapsulation.
/// </summary>
public class Memento
{
    public string State { get; }

    public Memento(string state) => State = state;
}

public class Originator
{
    public string State { get; set; } = string.Empty;

    public Memento Save() => new Memento(State);
    public void Restore(Memento memento) => State = memento.State;
}

public class Caretaker
{
    public Memento? Memento { get; set; }
}