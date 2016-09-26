using System.Web.Mvc;
using System.Web.Routing;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server
{
    public class RouteConfig
    {
        #region Public methods

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }

        #endregion
    }
}
