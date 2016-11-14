using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class GlobalExceptionAttribute : HandleErrorAttribute
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void OnException(ExceptionContext filterContext)
        {
            var message = filterContext.Exception.Message;
            //记录日志
            logger.Error(message, filterContext.Exception);
            base.OnException(filterContext);
            //抛出异常信息
            //filterContext.Controller.TempData["ExceptionAttributeMessages"] = message;

            ////转向
            //filterContext.ExceptionHandled = true;
            //filterContext.Result = new RedirectResult(Glo.ApplicationDirectory + "/Error/ErrorDetail/");
        }
    }
}
