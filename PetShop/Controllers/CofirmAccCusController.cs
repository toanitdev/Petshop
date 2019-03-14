using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.Encode;

namespace PetShop.Controllers
{
    public class CofirmAccCusController : Controller
    {
        // GET: CofirmAccCus
        
        public ActionResult Index(string code)
        {
            string x =  Vigenere.DeCode(code);
            CustomerModel model = new CustomerModel();
            model.Active(x.ToString().ToLower());
            
            return View();
        }
    }
}