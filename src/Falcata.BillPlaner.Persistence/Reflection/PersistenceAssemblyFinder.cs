using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Falcata.BillPlaner.Persistence.Reflection;

[ExcludeFromCodeCoverage]
public static class PersistenceAssemblyFinder
{ 
    public static Assembly GetAssembly() => typeof(PersistenceAssemblyFinder).Assembly;
}