using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using Szczepanik.Lukasz.PluggableMvcDemo.Common;
using Szczepanik.Lukasz.PluggableMvcDemo.Server;

[assembly: PreApplicationStartMethod(typeof(PreApplicationStart), "Start")]

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server
{
    public class PreApplicationStart
    {
        public static void Start()
        {
            var pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins", "Assemblies");
            foreach (var file in Directory.GetFiles(pluginPath, "*.dll"))
            {
                var assembly = Assembly.LoadFile(file);
                PluginAssembliesCache.AssemblyCache.TryAdd(file, assembly);
                BuildManager.AddReferencedAssembly(assembly);
            }
        }
    }
}