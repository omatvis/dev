using System;
using System.Linq;
using System.Reflection;

namespace Vocabulary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly? myApp = Assembly.GetEntryAssembly();
            if (myApp == null) return;
            foreach(AssemblyName name in myApp.GetReferencedAssemblies())
            {
                Assembly a = Assembly.Load(name);
                int methodCount = 0;
                foreach(TypeInfo t in a.DefinedTypes)
                {
                    methodCount += t.GetMethods().Length;
                }

                Console.WriteLine("{0:N0} types with {1:N0} methods in {2}",
                    a.DefinedTypes.Count(), methodCount, name.Name);
            }
        }
    }
}
