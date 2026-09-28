using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Behavioral_Patterns;

/// <summary>
/// The Observer Design Pattern is a behavioral design pattern that allows an object, 
/// known as the subject, to maintain a list of its dependents, called observers, 
/// and notify them of any state changes, usually by calling one of their methods.
/// </summary>
public interface IObserver { void Update(string message); }

public class Subject
{
    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer) => _observers.Add(observer);
    public void Detach(IObserver observer) => _observers.Remove(observer);

    public void Notify(string message)
    {
        foreach (var observer in _observers) observer.Update(message);
    }
}

public class ConcreteObserver : IObserver
{
    public void Update(string message) => Console.WriteLine($"Received: {message}");
}