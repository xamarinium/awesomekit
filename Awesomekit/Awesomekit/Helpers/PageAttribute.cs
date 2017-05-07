using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesomekit.Helpers
{
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
