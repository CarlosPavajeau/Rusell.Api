using System.Collections.Concurrent;
using System.Reflection;

namespace Rusell.Shared.Helpers;

public static class AssemblyHelper
{
    private static readonly ConcurrentDictionary<string, Assembly> Assemblies = new();

    public static Assembly GetInstance(string key) => Assemblies.GetOrAdd(key, Assembly.Load(key));
}