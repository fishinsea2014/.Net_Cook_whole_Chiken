using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RemarkAttribute: Attribute
    {
        public RemarkAttribute(string name)
        {
            this._Name = name;
        }

        private string _Name = null;

        public string GetRemark()
        {
            return this._Name;
        }
    }
}
