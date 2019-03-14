using Models.DAO;
using PetShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class OrderCustomerController : Controller
    {
        // GET: OrderCustomer
        public ActionResult Index()
        {
            return View(new OrderModel().GetListByCustomer(((UserLogin)Session[Common.CommonConstants.CUSTOMER_SESSION]).UserName));
        }

        // GET: OrderCustomer/Details/5
        public ActionResult Details(long id)
        {
            return View(new OrderDetailsModel().GetDetailsByOrderID(id));
        }

        // GET: OrderCustomer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderCustomer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderCustomer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderCustomer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderCustomer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderCustomer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
