using System;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Common
{
    public interface IControllerMetadata
    {
        Type ControllerType { get; }
        string ControllerName { get; }
    }
}