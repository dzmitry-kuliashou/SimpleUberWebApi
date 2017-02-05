using System;

namespace SimpleUber.Services.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class ValidationRequiredAttribute : Attribute
    {
    }
}
