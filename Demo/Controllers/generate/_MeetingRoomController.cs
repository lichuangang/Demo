using Entity.Demo;
using Framework;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{	

	public partial class MeetingRoomController : Controller
    {

		MeetingRoomService service = new MeetingRoomService();

		[HttpPost]
        public ActionResult Grid(MeetingRoomQuery query)
        {
            var result = service.Grid(query);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
		