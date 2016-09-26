using System.ComponentModel.Composition;
using System.Web.Mvc;
using Szczepanik.Lukasz.PluggableMvcDemo.Common;
using Szczepanik.Lukasz.PluggableMvcDemo.Common.Attributes;
using Szczepanik.Lukasz.PluggableMvcDemo.Common.BaseClasses;

namespace Szczepanik.Lukasz.PluggableMvcDemo.PluginTwo.Controllers
{
    [Export(typeof (IController))]
    [ExportMetadata(Consts.CONTROLLER_TYPE, typeof (PluginTwoController))]
    [ExportMetadata(Consts.CONTROLLER_NAME, "PluginOne")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ControllerMethod("PluginTwo", "Index", "Index from PluginControllerTwo")]
    public class PluginTwoController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}