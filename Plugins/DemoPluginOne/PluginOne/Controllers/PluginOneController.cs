using System.ComponentModel.Composition;
using System.Web.Mvc;
using Szczepanik.Lukasz.PluggableMvcDemo.Common;

namespace Szczepanik.Lukasz.PluggableMvcDemo.PluginOne.Controllers
{
    [Export(typeof (IController))]
    [ExportMetadata(Consts.CONTROLLER_TYPE, typeof (PluginOneController))]
    [ExportMetadata(Consts.CONTROLLER_NAME, "PluginOne")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PluginOneController : BaseController
    {
        public string Index()
        {
            return "hello from plugin one!";
        }
    }
}
