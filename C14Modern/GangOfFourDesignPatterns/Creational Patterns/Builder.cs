using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Creational_Pattern;


/// <summary>
/// Allows step-by-step construction of complex objects, isolating construction from the final object.
/// </summary>
public class Building
{
    public string PartA { get; set; } = String.Empty;
    public string PartB { get; set; } = String.Empty;
    public string PartC { get; set; } = String.Empty;
}

public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
    Building GetProduct();
}

public class ConcreteBuilder : IBuilder
{
    private Building _building = new Building();

    public void BuildPartA() => _building.PartA = "PartA";
    public void BuildPartB() => _building.PartB = "PartB";
    public void BuildPartC() => _building.PartC = "PartC";

    public Building GetProduct()
    {
        Building result = _building;
        _building = new Building();  // Reset
        return result;
    }
}

public class Director
{
    private IBuilder _builder;

    public Director(IBuilder builder) => _builder = builder;

    public void Construct()
    {
        _builder.BuildPartA();
        _builder.BuildPartB();
        _builder.BuildPartC();
    }
}