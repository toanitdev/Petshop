using Models.Class;
using Models.DAO;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        [HttpPost]
        public ActionResult Index(Account account)
        {

            bool res = new AccountCustomer().Login(account.userName, Common.Encrytion.MD5Hash(account.password));
            if (res)
            {
                CustomerModel cus = new CustomerModel();
                var user = cus.GetCustomer(account.userName);
                var userSesion = new Common.UserLogin();
                userSesion.UserName = account.userName;
                Session.Add(Common.CommonConstants.CUSTOMER_SESSION, userSesion);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("","Sai mật khẩu");
            }
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
