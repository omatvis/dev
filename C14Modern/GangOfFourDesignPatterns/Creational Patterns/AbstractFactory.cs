using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Creational_Pattern;

/// <summary>
/// Lets you create families of related objects without stating their specific concrete classes.
/// </summary>

public interface IButton { void Render(); }
public interface ICheckbox { void Render(); }

public class WindowsButton : IButton { public void Render() => Console.WriteLine("Rendering Windows Button"); }
public class WindowsCheckbox : ICheckbox { public void Render() => Console.WriteLine("Rendering Windows Checkbox"); }

public class MacButton : IButton { public void Render() => Console.WriteLine("Rendering Mac Button"); }
public class MacCheckbox : ICheckbox { public void Render() => Console.WriteLine("Rendering Mac Checkbox"); }

public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

public class WindowsFactory : IGUIFactory
{
    public IButton CreateButton() => new WindowsButton();
    public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

