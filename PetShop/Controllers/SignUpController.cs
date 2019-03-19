using Models;
using Models.DAO;
using Models.Encode;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }
   
        // GET: SignUp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SignUp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SignUp/Create
        [HttpPost]
        public ActionResult Create(string sa,Customer customer)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    if(customer.CustomerID != "" && sa != "")
                    {
                        if (customer.Password== sa)
                        {
                            String MD5 = Common.Encrytion.MD5Hash(customer.Password);
                            customer.Password = MD5;
                            new AccountCustomer().Create(customer);
                            MailService mail = new MailService();
                            mail.SendMail(mail.MailSignUp(Vigenere.Encode(customer.CustomerID.ToUpper())), customer.Email);
                            return RedirectToAction("Success", "SignUp");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Xác nhận mật khẩu không đúng");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi đăng ký");
                }

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: SignUp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SignUp/Edit/5
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

        // GET: SignUp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SignUp/Delete/5
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

        public ActionResult Success()
        {
            return View();

        }
    }
}
