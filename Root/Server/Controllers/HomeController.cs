using System.ComponentModel.Composition;
using System.Web.Mvc;
using Szczepanik.Lukasz.PluggableMvcDemo.Common;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server.Controllers
{
    [Export(typeof (IController))]
    [ExportMetadata(Consts.CONTROLLER_NAME, "Home")]
    [ExportMetadata(Consts.CONTROLLER_TYPE, typeof (HomeController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact details.";

            return View();
        }
    }
}