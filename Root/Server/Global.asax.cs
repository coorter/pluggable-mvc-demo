﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MefConfig.RegisterMef();
            ViewEnginesConfig.RegisterViewEngines(ViewEngines.Engines);
        }
    }
}
