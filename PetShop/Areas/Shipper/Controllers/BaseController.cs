using PetShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Areas.Shipper.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userLogin = (UserLogin)Session[Common.CommonConstants.SHIPPER_SESSION];
            if (userLogin == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Shipper" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}