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
            string connectionStr = ConfigurationManagerUtil.Get(dbName);
            var config = new ConnectionConfig()
            {
                ConnectionString = connectionStr, //必填
                DbType = DbType.SqlServer, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.SystemTable //默认SystemTable
            };
            return new SqlSugarClient(config);
        }
    }
}
