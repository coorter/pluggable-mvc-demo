using System;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ControllerMethodAttribute : Attribute
    {
        public ControllerMethodAttribute(string controllerName, string methodName, string displayText)
        {
            ControllerName = controllerName;
            MethodName = methodName;
            DisplayText = displayText;
        }

        public string ControllerName { get; }
        public string MethodName { get; }
        public string DisplayText { get; }
    }
}