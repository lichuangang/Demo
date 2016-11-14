using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Extend
{
    public static class JsonExtend
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObj<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }


    }
}
