using System;

namespace Awesomekit.Helpers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PageAttribute : Attribute
    {
        public string Name { get; set; }

        public PageAttribute()
        {
        }

        public PageAttribute(string name)
        {
            Name = name;
        }
    }
}
