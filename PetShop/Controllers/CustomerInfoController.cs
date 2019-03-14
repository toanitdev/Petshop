using Models.DAO;
using PetShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class CustomerInfoController : Controller
    {
        // GET: CustomerInfo
        public ActionResult Index()
        {
            var cus = new AccountCustomer().GetCustomer(((UserLogin)Session[Common.CommonConstants.CUSTOMER_SESSION]).UserName);
            return View(cus);
        }

        // GET: CustomerInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerInfo/Create
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

        // GET: CustomerInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerInfo/Edit/5
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

        // GET: CustomerInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerInfo/Delete/5
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
