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

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Menu()
        {
            var result = service.GetMenuModule(m =>
            {
                return Url.Content(m);
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}