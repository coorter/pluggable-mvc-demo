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
using Szczepanik.Lukasz.PluggableMvcDemo.Common.Attributes;
using Szczepanik.Lukasz.PluggableMvcDemo.Common.BaseClasses;

namespace Szczepanik.Lukasz.PluggableMvcDemo.PluginOne.Controllers
{
    [Export(typeof (IController))]
    [ExportMetadata(Consts.CONTROLLER_TYPE, typeof (PluginOneController))]
    [ExportMetadata(Consts.CONTROLLER_NAME, "PluginOne")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ControllerMethod("PluginOne", "Index", "Index method from PluginOneController")]
    public class PluginOneController : BaseController
    {
        #region Public methods

        public ViewResult Index()
        {
            return View();
        }

        #endregion
    }
}
