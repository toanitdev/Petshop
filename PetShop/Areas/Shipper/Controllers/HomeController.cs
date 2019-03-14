using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Areas.Shipper.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Shipper/Home
        public ActionResult Index()
        {

            var orderlist = new  OrderModel().GetListByShip(((Common.UserLogin)Session[Common.CommonConstants.SHIPPER_SESSION]).UserName);
            return View(orderlist);
        }
        public ActionResult DonChuaGiao()
        {
            var orderlist = new  OrderModel().GetListByShip(((Common.UserLogin)Session[Common.CommonConstants.SHIPPER_SESSION]).UserName);
            List<Order> l = new List<Order>();

            foreach (var item in orderlist)
            {
                if (item.Status != 4 && item.Status != 5)
                {
                    l.Add(item);
                }
            }

            return View(l);
        }
        public ActionResult DonDaGiao()
        {
            var orderlist = new  OrderModel().GetListByShip(((Common.UserLogin)Session[Common.CommonConstants.SHIPPER_SESSION]).UserName);
            List<Order> l = new List<Order>();

            foreach (var item in orderlist)
            {
                if (item.Status == 4 || item.Status == 5)
                {
                    l.Add(item);
                }
            }
            
            return View(l);
        }
        public ActionResult None()
        {
            return View();
        }
       
        public ActionResult Giao(long id)
        {

            Order or = new  OrderModel().GetOrder(id);
            or.Status = 4;
            new  OrderModel().Update(id,or);
            return RedirectToAction("DonChuaGiao", "Home");
        }

  
        public ActionResult Huy(long id)
        {
            Order or = new  OrderModel().GetOrder(id);
            or.Status = 5;
            new  OrderModel().Update(id, or);
            return RedirectToAction("DonChuaGiao", "Home");
        }
        public ActionResult Details(long id) {
            var r = new OrderDetailsModel().GetDetailsByOrderID(id);

            return View(r);

        }
    }
}