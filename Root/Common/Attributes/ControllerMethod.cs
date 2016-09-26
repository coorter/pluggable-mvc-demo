/**
 * @license
 * Copyright Łukasz Szczepanik. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/coorter/pluggable-mvc-demo/blob/master/LICENSE
 */

using System;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ControllerMethodAttribute : Attribute
    {
        #region Ctors

        public ControllerMethodAttribute(string controllerName, string methodName, string displayText)
        {
            ControllerName = controllerName;
            MethodName = methodName;
            DisplayText = displayText;
        }

        #endregion
        #region Properties

        public string ControllerName { get; }
        public string MethodName { get; }
        public string DisplayText { get; }

        #endregion
    }
}