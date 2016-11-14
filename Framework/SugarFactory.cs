using Common;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class SugarFactory
    {
        private SugarFactory() { }

        public static SqlSugarClient GetInstance(string dbName)
        {
            //可以根据不同的DB字符串，实现多库查询及读写分离
            string sqlLink=ConfigurationManagerUtil.Get(dbName);
            var db = new SqlSugarClient(sqlLink);

            return db;
        }
    }
}
