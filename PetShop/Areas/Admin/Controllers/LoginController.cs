using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using PetShop.Areas.Admin.Code;
using Models.DAO;
using PetShop.Common;
using Models.Class;

namespace PetShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            { 
                var userDao = new UserDAO();
                var res = userDao.Login(model.userName,Common.Encrytion.MD5Hash(model.password));
                if (res)
                {
                    var user = userDao.GetAccount(model.userName);
                    var userSesion = new UserLogin();
                    userSesion.UserName = user.Username;
                    Session.Add(Common.CommonConstants.USER_SESSION,userSesion);
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

    }
}