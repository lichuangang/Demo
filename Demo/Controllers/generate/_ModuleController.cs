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

	public partial class ModuleController : Controller
    {

		ModuleService service = new ModuleService();

		[HttpPost]
        public ActionResult Grid(ModuleQuery query)
        {
            var result = service.Grid(query);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
		