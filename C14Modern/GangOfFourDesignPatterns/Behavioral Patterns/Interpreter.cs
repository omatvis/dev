using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Behavioral_Patterns;

/// <summary>
/// The Interpreter pattern is a behavioral design pattern that defines a representation for a grammar of a language and provides an interpreter to deal with this grammar. It is used to interpret sentences in a language defined by a grammar. The pattern is useful when you have a simple language to interpret, and you want to represent the grammar of that language in code.
/// </summary>

// 1. Context stores state (variables)
public class Context
{
    private readonly Dictionary<string, int> _variables = new();

    public void SetVariable(string name, int value) => _variables[name] = value;

    public int GetVariable(string name) => _variables.TryGetValue(name, out var value) ? value : 0;
}

// Abstract Expression
public interface IExpression
{
    int Interpret(Context context);
}

// 3. Terminal Expression (Constant Number)
public class NumberExpression : IExpression
{
    private readonly int _number;

    public NumberExpression(int number) => _number = number;

    public int Interpret(Context context) => _number;
}

// 4. Terminal Expression (Variable)
public class VariableExpression : IExpression
{
    private readonly string _name;

    public VariableExpression(string name) => _name = name;

    public int Interpret(Context context) => context.GetVariable(_name);
}

// 5. Non-Terminal Expression (Addition)
public class AddExpression : IExpression
{
    private readonly IExpression _left;
    private readonly IExpression _right;

    public AddExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context context) => _left.Interpret(context) + _right.Interpret(context);
}

