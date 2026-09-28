using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Behavioral_Patterns;

/// <summary>
/// Encapsulates a request as an object, thereby allowing for parameterization of clients with queues, requests, and operations. It also allows for undoable operations.
/// </summary>

// Command
public interface ICommand
{
    void Execute();
}

// Receiver
public class Light
{
    public void On()
    {
        Console.WriteLine("Light is ON");
    }
    public void Off()
    {
        Console.WriteLine("Light is OFF");
    }
}

// ConcreteCommand
public class LightOnCommand : ICommand
{
    private Light _light;
    public LightOnCommand(Light light)
    {
        _light = light;
    }
    public void Execute()
    {
        _light.On();
    }
}

// Invoker
public class RemoteControl
{
    private ICommand? _command;
    public void SetCommand(ICommand command)
    {
        _command = command;
    }
    public void PressButton()
    {
        _command?.Execute();
    }
}
