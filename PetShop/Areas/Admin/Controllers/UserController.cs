using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            var userDao = new UserDAO();
            var user = userDao.GetAccountList();
            return View(user);
        }
       
        public ActionResult Edit(string userName)
        {
            var userDao = new UserDAO();
            var user = userDao.GetAccount(userName);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(string id,Account account)
        {
            if (ModelState.IsValid)
            {
                var userDao = new UserDAO();
                string MD5Pass = Common.Encrytion.MD5Hash(account.Password);
                account.Password = MD5Pass;
                account.Username = id;
                bool res = userDao.Update(account);

                if (res)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa ko thành công");
                }

            }
            else
            {


            }

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Account user)
        {
            if (ModelState.IsValid) { 
                var userDao = new UserDAO();
                string MD5Pass = Common.Encrytion.MD5Hash(user.Password);
                user.Password = MD5Pass;
                string userName = userDao.Insert(user);
               
                if (userName != null)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thành công");
                }
                
            }
            else
            {
                

            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new UserDAO().Delete(id);
            
           
            return  RedirectToAction("Index");
        }
    }
}