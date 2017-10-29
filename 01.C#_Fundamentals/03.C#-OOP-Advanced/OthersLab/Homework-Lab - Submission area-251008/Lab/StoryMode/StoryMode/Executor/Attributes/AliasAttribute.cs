using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AliasAttribute : Attribute
    {
        private string name;
        public AliasAttribute(string aliasName)
        {
            this.name = aliasName;
        }
        public string Name => this.name;
        public override bool Equals(object obj) => this.name.Equals(obj);
    }
}
