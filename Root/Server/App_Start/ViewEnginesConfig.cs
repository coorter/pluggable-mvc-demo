/**
 * @license
 * Copyright Łukasz Szczepanik. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/coorter/pluggable-mvc-demo/blob/master/LICENSE
 */

using System.Web.Mvc;
using Szczepanik.Lukasz.PluggableMvcDemo.Server.Custom;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server
{
    public class ViewEnginesConfig
    {
        #region Public methods

        public static void RegisterViewEngines(ViewEngineCollection viewEngineCollection)
        {
            viewEngineCollection.Clear();
            viewEngineCollection.Add(new PluggableViewEngine());
        }

        #endregion
    }
}