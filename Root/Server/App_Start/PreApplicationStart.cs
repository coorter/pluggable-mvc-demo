using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using Szczepanik.Lukasz.PluggableMvcDemo.Common;
using Szczepanik.Lukasz.PluggableMvcDemo.Server;

[assembly: PreApplicationStartMethod(typeof (PreApplicationStart), "Start")]

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server
{
    public class PreApplicationStart
    {
        #region Public methods

        public static void Start()
        {
            string pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins", "Assemblies");
            foreach (string file in Directory.GetFiles(pluginPath, "*.dll"))
            {
                Assembly assembly = Assembly.LoadFile(file);
                PluginAssembliesCache.AssemblyCache.TryAdd(file, assembly);
                BuildManager.AddReferencedAssembly(assembly);
            }
        }

        #endregion
    }
}