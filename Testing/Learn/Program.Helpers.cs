using System;

namespace Learn;

partial class Program
{
    public static void RunForEach()
    {
        // Loop from 1 to 100 implementing IEnumerable and IEnumerator
        ArtificialSequence seq = new();
        foreach (int item in seq)
        {
            Console.WriteLine(item);
        }
    }
}

public class BaseClass : Object
{
    public virtual void BaseMethod()
    {
        WriteLine("Basic run");
    }

    public void MethodToHideInChild()
    {
        WriteLine("Parent: MethodToHideInChild");
    }
}

public interface IBaseClass
{
    void Start();
}

public class ChildBaseClass : BaseClass, IBaseClass
{
    public void Start()
    {
        throw new NotImplementedException();
    }

    public override void BaseMethod()
    {
        WriteLine("Child before call base method");
        base.BaseMethod();
        WriteLine("BaseMethod overriden");
    }

    public new void MethodToHideInChild()
    {
        WriteLine("Child: MethodToHideInChild");
    }
}
