/**
 * @license
 * Copyright Łukasz Szczepanik. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/coorter/pluggable-mvc-demo/blob/master/LICENSE
 */

using System;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Common
{
    public interface IControllerMetadata
    {
        Type ControllerType { get; }
        string ControllerName { get; }
    }
}