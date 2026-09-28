using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Behavioral_Patterns;

/// <summary>
/// The Strategy Design Pattern is a behavioral design pattern that enables selecting an algorithm's behavior at runtime.
/// </summary>

public interface IStrategy { void Algorithm(); }

public class ConcreteStrategyA : IStrategy { public void Algorithm() => Console.WriteLine("Strategy A"); }
public class ConcreteStrategyB : IStrategy { public void Algorithm() => Console.WriteLine("Strategy B"); }

public class ContextStrategy
{
    private IStrategy _strategy;

    public ContextStrategy(IStrategy strategy) => _strategy = strategy;

    public void Execute() => _strategy.Algorithm();
}