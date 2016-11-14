using Dao.Demo;
using Entity.Demo;
using Framework;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public partial class ModuleService
    {

        public HxResult Add(Module model)
        {
            dao.Add(model);

            return new HxResult();
        }

        public HxResult Edit(Module model)
        {
            dao.Edit(model);

            return new HxResult();
        }

        public HxResult Delete(int id)
        {
            dao.Delete<int>(id);
            return new HxResult();
        }

        public HxResult GetMenuModule(Func<string, string> urlHandle)
        {
            HxResult result = new HxResult();
            var data = dao.ToList(m => m.IsShow == true);
            foreach (var item in data)
            {
                //url需要处理
                item.Url = urlHandle(item.Url);
            }
            result.Data = data;
            return result;
        }
    }
}
