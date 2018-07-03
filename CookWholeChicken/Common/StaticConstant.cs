using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    class StaticConstant
    {
        //Should reference system.configruation first.
        public static string LogRootPath = System.Configuration.ConfigurationManager.AppSettings["LogRootPath"];
    }
}
