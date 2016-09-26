using System.Web.Mvc;
using Szczepanik.Lukasz.PluggableMvcDemo.Server.Custom;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server
{
    public class ViewEnginesConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection viewEngineCollection)
        {
            viewEngineCollection.Clear();
            viewEngineCollection.Add(new PluggableViewEngine());
        }
    }
}