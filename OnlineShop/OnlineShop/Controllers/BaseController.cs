using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common;
using System.Web.Routing;

namespace OnlineShop.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var seesion = (UserLogin)Session[CommonConstants.USER_SEESION];
            if (seesion == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Login", Area = "Controllers" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}