using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Creational_Pattern;

/// <summary>
/// Lets you copy an existing object instead of making a new one from scratch.
/// </summary>

public class Prototype : ICloneable
{
    public string Property { get; set; } = String.Empty;

    public object Clone() => MemberwiseClone();  // Shallow clone
}