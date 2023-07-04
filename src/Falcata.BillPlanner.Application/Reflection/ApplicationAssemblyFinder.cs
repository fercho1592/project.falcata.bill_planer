using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Falcata.BillPlanner.Application.Reflection;

[ExcludeFromCodeCoverage]
public static class ApplicationAssemblyFinder
{
    public static Assembly GetAssembly() => typeof(ApplicationAssemblyFinder).Assembly;
}