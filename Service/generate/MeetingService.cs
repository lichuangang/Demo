using Cache;
using Dao.Demo;
using Entity.Demo;
using Framework;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{	
	public partial class MeetingService
    {
		Func<PageData<Meeting>, object> searchFunc = null;

		MeetingDao dao = new MeetingDao();

		public HxResult Grid(MeetingQuery query)
        {
            HxResult result = new HxResult();
            dao.Page(query);
			if (searchFunc != null)
            {
                result.Data = searchFunc(query.Result);
            }
            else
            {
                result.Data = query.Result;
            }
            return result;
        }

    }
}
		