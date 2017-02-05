using System;

namespace SimpleUber.Distribution.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class PartlySuppressedLoggingAttribute : Attribute
    {
    }
}
