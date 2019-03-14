using Models;
using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = new ProductModel().ListProduct();
            return View(list);
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}