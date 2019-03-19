using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {

            Session[Common.CommonConstants.CUSTOMER_SESSION] = null;
            return RedirectToAction("Index","Home");
        }
    }
}