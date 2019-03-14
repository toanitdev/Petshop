using Models;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult Index(long productId)
        {
            var product = new ProductModel().ViewDetail(productId);
            return View(product);
        }
    }
}