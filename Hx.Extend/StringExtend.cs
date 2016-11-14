using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Extend
{
    public static class StringExtend
    {
        public static string FormatStr(this string resource, params object[] args)
        {
            return string.Format(resource, args);
        }

        /// <summary>
        /// 从某个位置开始替换内容
        /// 如果长度超范围，则执行插入
        /// </summary>
        public static string Replace(this string res, int index, string to)
        {
            if (index > res.Length) throw new Exception("起始长度超出范围了");
            string start = res.Substring(0, index);

            string end = string.Empty;
            if (index + to.Length > res.Length)
            {
                //如果超出长度了，直接强制插入
                end = res.Substring(index);
            }
            else
            {
                end = res.Substring(index + to.Length);
            }
            return start + to + end;
        }

        /// <summary>
        /// 将utc时间转为北京时间
        /// 加８个小时
        /// </summary>
        public static string UtcTimeConvertCnTime(this string utcTime)
        {
            DateTime time = DateTime.Parse(utcTime);
            //北京时间就是世界时间+８小时
            return time.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
