using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Class;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult SanPham()
        {
            ViewBag.Mes = "Tin nhắn với viewbag";
            var mes = new MesModel();
            
            mes.Mes = "Tin nhắn từ Model";

            return View(mes);
        }
    }
}