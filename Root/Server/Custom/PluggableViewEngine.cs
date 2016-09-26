using System.Linq;
using System.Web.Mvc;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server.Custom
{
    public class PluggableViewEngine : RazorViewEngine
    {
        #region Consts

        private static readonly string[] PluginViewsLocations =
        {
            "~/Plugins/Views/{1}/{0}.cshtml",
            "~/Plugins/Views/{1}/{0}.vbhtml"
        };

        #endregion

        public PluggableViewEngine()
        {
            ViewLocationFormats = ViewLocationFormats.Concat(PluginViewsLocations).ToArray();
        }
    }
}