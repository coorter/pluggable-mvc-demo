using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Web;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Common
{
    public class PluginAssembliesCache
    {
        public static string PluginsPath => Path.Combine(HttpContext.Current.Server.MapPath(""), "Plugins", "Assemblies");

        public static ConcurrentDictionary<string, Assembly> AssemblyCache { get; } = new ConcurrentDictionary<string, Assembly>();
    }
}
