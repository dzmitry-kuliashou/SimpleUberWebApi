using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dispatcher;

public class CustomAssemblyResolver : IAssembliesResolver
{
    public ICollection<Assembly> GetAssemblies()
    {
        var baseAssemblies = new List<Assembly>();
        var controllersAssembly = Assembly.LoadFrom("SimpleUber.Distribution");
        baseAssemblies.Add(controllersAssembly);
        return baseAssemblies;
    }
}