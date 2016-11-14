using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class DbNameAttribute : Attribute
    {
        private string dbName;

        public DbNameAttribute(string dbName)
        {
            this.dbName = dbName;
        }

        public string DbName
        {
            get { return dbName; }
        }
    }
}
