/**
 * @license
 * Copyright Łukasz Szczepanik. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/coorter/pluggable-mvc-demo/blob/master/LICENSE
 */

using System.ComponentModel.Composition;
using System.Web.Mvc;
using Szczepanik.Lukasz.PluggableMvcDemo.Common;
using Szczepanik.Lukasz.PluggableMvcDemo.Common.BaseClasses;
using Szczepanik.Lukasz.PluggableMvcDemo.Server.Custom;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server.Controllers
{
    [Export(typeof (IController))]
    [ExportMetadata(Consts.CONTROLLER_NAME, "Home")]
    [ExportMetadata(Consts.CONTROLLER_TYPE, typeof (HomeController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : BaseController
    {
        #region Public methods

        public ActionResult Index()
        {
            ViewBag.PluginsMethods = ControllerMethodsHelper.GetControllerMethodAttributes();
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

        #endregion
    }
}