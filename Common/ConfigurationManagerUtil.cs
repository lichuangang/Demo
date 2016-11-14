using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ConfigurationManagerUtil
    {
        public static string Get(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public static string AppSet(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
