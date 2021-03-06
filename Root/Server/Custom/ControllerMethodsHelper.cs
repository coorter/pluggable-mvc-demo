﻿/**
 * @license
 * Copyright Łukasz Szczepanik. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/coorter/pluggable-mvc-demo/blob/master/LICENSE
 */

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Szczepanik.Lukasz.PluggableMvcDemo.Common;
using Szczepanik.Lukasz.PluggableMvcDemo.Common.Attributes;
using WebGrease.Css.Extensions;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server.Custom
{
    public class ControllerMethodsHelper
    {
        #region Public methods

        public static IEnumerable<ControllerMethodAttribute> GetControllerMethodAttributes()
        {
            var enumerable = new List<ControllerMethodAttribute>();

            PluginAssembliesCache.AssemblyCache.ForEach(a =>
            {
                a.Value.GetExportedTypes().ForEach(type =>
                {
                    var attributes = type.GetCustomAttributes(typeof (ControllerMethodAttribute)).Cast<ControllerMethodAttribute>();
                    if (attributes != null && attributes.Any())
                    {
                        enumerable.AddRange(attributes);
                    }
                });
            });

            return enumerable;
        }

        #endregion
    }
}