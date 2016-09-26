using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Common.BaseClasses
{
    public class PluggableViewPage : WebViewPage
    {
        #region Overrides of WebPageExecutingBase

        public override void Execute()
        {
        }

        #endregion
        #region Overrides of WebViewPage

        public override void ExecutePageHierarchy()
        {
            try
            {
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                base.ExecutePageHierarchy();
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly assembly = PluginAssembliesCache.AssemblyCache.Values.FirstOrDefault(v => v.FullName == args.Name);
            return assembly;
        }

        #endregion
    }
}