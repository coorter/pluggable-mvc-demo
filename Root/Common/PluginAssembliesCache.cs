/**
 * @license
 * Copyright Łukasz Szczepanik. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/coorter/pluggable-mvc-demo/blob/master/LICENSE
 */

using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Web;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Common
{
    public class PluginAssembliesCache
    {
        #region Properties

        public static string PluginsPath => Path.Combine(HttpContext.Current.Server.MapPath(""), "Plugins", "Assemblies");

        public static ConcurrentDictionary<string, Assembly> AssemblyCache { get; } = new ConcurrentDictionary<string, Assembly>();

        #endregion
    }
}
