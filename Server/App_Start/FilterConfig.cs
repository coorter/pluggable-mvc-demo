﻿using System.Web.Mvc;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
