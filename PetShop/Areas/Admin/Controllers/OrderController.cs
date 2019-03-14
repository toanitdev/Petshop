
using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index()
        {

            return View(new OrderModel().GetList());
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(long id)
        {
            var r = new OrderDetailsModel().GetDetailsByOrderID(id);
           
            return View(r);
        }

        // GET: Admin/Order/Create
        public ActionResult Create()
        {
            long? selectedId = null;
            var dao = new CustomerModel();
            ViewBag.CustomerID = new SelectList(dao.GetList(),"CustomerID", "CustomerID", selectedId);
            var Udao = new UserDAO();
            ViewBag.Username = new SelectList(Udao.GetAccountList(), "Username", "Username", selectedId);
            return View();
        }

        // POST: Admin/Order/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            try
            {
                // TODO: Add insert logic here
                new OrderModel().Insert(order);
                return RedirectToAction("Index","Order");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Order/Edit/5
        public ActionResult Edit(long id)
        {
            long? selectedId = null;
            var dao = new  CustomerModel();
            ViewBag.CustomerID = new SelectList(dao.GetList(), "CustomerID", "CustomerID", selectedId);
            var Udao = new UserDAO();
            ViewBag.Username = new SelectList(Udao.GetAccountList(), "Username", "Username", selectedId);
            return View(new  OrderModel().GetOrder(id));
        }

        // POST: Admin/Order/Edit/5
        [HttpPost]
        public ActionResult Edit(long id, Order order)
        {
            try
            {
                // TODO: Add update logic here
                new  OrderModel().Update(id, order);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Order/Delete/5
        public ActionResult Delete(int id)
        {
            new  OrderModel().Delete(id);
            return View();
        }

        // POST: Admin/Order/Delete/5
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
