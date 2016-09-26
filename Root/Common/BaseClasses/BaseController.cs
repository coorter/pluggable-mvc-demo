using System.Web.Mvc;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Common.BaseClasses
{
    public class BaseController : Controller
    {
        #region Ctors

        public BaseController()
        {
            ViewBag.Title = "Pluggable MVC Application";
        }

        #endregion
    }
}
