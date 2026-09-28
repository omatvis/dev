using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Behavioral_Patterns;

/// <summary>
/// The Mediator Design Pattern is a behavioral design pattern that restricts direct communications between objects 
/// and forces them to collaborate only via a central mediator object. 
/// This pattern helps reduce tight coupling between classes by making objects communicate with each other through the mediator 
/// instead of calling each other directly.
/// </summary>
public interface IChatMediator
{
    void SendMessage(string message, User sender);
    void AddUser(User user);
}

// 2. Colleague Abstract Class
public abstract class User
{
    protected IChatMediator mediator;
    public string Name { get; }

    protected User(IChatMediator mediator, string name)
    {
        this.mediator = mediator;
        Name = name;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

public class ChatRoom : IChatMediator
{
    private readonly List<User> _users = new();

    public void AddUser(User user) => _users.Add(user);

    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            // Do not send the message back to the sender
            if (user != sender)
            {
                user.Receive(message);
            }
        }
    }
}

// 4. Concrete Colleague
public class ChatUser : User
{
    public ChatUser(IChatMediator mediator, string name) : base(mediator, name) { }

    public override void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        mediator.SendMessage(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{Name} receives: {message}");
    }
}