/**
 * @license
 * Copyright Łukasz Szczepanik. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/coorter/pluggable-mvc-demo/blob/master/LICENSE
 */

using System.Linq;
using System.Web.Mvc;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server.Custom
{
    public class PluggableViewEngine : RazorViewEngine
    {
        #region Consts

        private static readonly string[] PluginViewsLocations =
        {
            "~/Plugins/Views/{1}/{0}.cshtml",
            "~/Plugins/Views/{1}/{0}.vbhtml"
        };

        #endregion
        #region Ctors

        public PluggableViewEngine()
        {
            ViewLocationFormats = ViewLocationFormats.Concat(PluginViewsLocations).ToArray();
        }

        #endregion
    }
}