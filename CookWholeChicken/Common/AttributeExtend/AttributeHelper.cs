using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.AttributeExtend
{
    public static class AttributeHelper
    {
        public static string GetColumnName(this PropertyInfo prop)
        {
            if (prop.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = (RemarkAttribute)prop.GetCustomAttribute(typeof(RemarkAttribute), true);
                return attribute.GetRemark();
            }
            else
            {
                return prop.Name;
            }

        }
    }
}
