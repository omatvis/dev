using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourDesignPatterns.Creational_Pattern;

/// <summary>
/// Ensures that a class has only one instance and provides a global point of access to it.
/// </summary>

public class Singelton
{
    private Singelton() { }

    public static readonly object _lock = new ();

    public static Singelton Instance
    {
        get
        {
            if (field == null)
            {
                lock (_lock) field ??= new Singelton();
            }
            return field;
        }
    }

    public bool SomeUsefulMethod()
    {
        return true;
    }
}
