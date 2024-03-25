using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Common.Json
{
    [AttributeUsage(AttributeTargets.Enum)]
    public class EnumNameAttribute : Attribute
    {
        private readonly string name;

        public EnumNameAttribute(string name)
        {
            this.name = name;
        }

        public string Name { get; }
    }
}
