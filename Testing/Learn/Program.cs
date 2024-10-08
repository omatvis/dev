using System.Numerics;
using System.Security.Cryptography;

namespace Learn;

partial class Program
{
    static void Main(string[] args)
    {   
        ChildBaseClass childBaseClass = new ();
        childBaseClass.BaseMethod();
        BaseClass baseClass = childBaseClass;
        baseClass.MethodToHideInChild();
        childBaseClass.MethodToHideInChild();
    }
}