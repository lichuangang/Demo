using Entity.Demo;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class ModuleQuery
    {
        //可以根据需要自己增加查询字段
        //例：Public String BeginDate { get;set;}
        //在重写的方法中写相关的查询判断

        /// <summary>
        /// 根据自己需求，返回where查询条件
        /// </summary>
        protected override List<Expression<Func<Module, bool>>> MakeWhere()
        {
            return null;
        }
    }
}
