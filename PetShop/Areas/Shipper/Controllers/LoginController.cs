using Models.DAO;
using Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Areas.Shipper.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var userDao = new UserDAO();
                var res = userDao.LoginShipper(model.userName, Common.Encrytion.MD5Hash(model.password));
                if (res)
                {
                    var user = userDao.GetAccount(model.userName);
                    var userSesion = new Common.UserLogin();
                    userSesion.UserName = user.Username;
                    Session.Add(Common.CommonConstants.SHIPPER_SESSION, userSesion);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng");

                }
            }
            else
            {

            }
            return View("Index");
        }

        // GET: Shipper/Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shipper/Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shipper/Login/Create
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

        // GET: Shipper/Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shipper/Login/Edit/5
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

        // GET: Shipper/Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shipper/Login/Delete/5
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
