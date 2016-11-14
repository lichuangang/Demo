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
    public partial class MeetingController : Controller
    {
        // GET: Meeting
        public ActionResult Index(DateTime? date)
        {
            if (date == null || date == DateTime.MinValue)
            {
                date = DateTime.Today;
            }
            return View("Index", date);
        }

        public ActionResult GetMeeting(DateTime date)
        {
            var result = service.GetMeeting(date);
            return Json(result, JsonRequestBehavior.AllowGet); ;
        }

        #region 保存会议
        [HttpPost]
        public ActionResult Save(MeetingDto model)
        {
            HxResult result = new HxResult();

            if (ModelState.IsValid)
            {
                result = service.Save(model);
            }
            else
            {
                result.Msg = string.Join("\r\n", ModelState.Select((item) => { return item.Key + ":" + item.Value; }));
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 查询
        public ActionResult Search()
        {

            return View();
        }
        #endregion

        #region 删除
        public ActionResult Delete(long id)
        {
            var result = service.DeleteById(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}