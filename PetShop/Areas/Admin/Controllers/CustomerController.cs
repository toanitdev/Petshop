using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {

            return View(new CustomerModel().GetList());
        }

        // GET: Admin/Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                string MD5Pass = Common.Encrytion.MD5Hash(customer.Password);
                customer.Password = MD5Pass;
                new CustomerModel().Insert(customer);
                return RedirectToAction("Index","Customer");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Customer/Edit/5
        public ActionResult Edit(string id)
        {
            Customer customer = new CustomerModel().GetCustomer(id);

            customer.Password = "";
            return View(customer);
        }

        // POST: Admin/Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Customer customer)
        {

            if (ModelState.IsValid)
            {
                var cus = new CustomerModel();
                string MD5Pass = Common.Encrytion.MD5Hash(customer.Password);
                customer.Password = MD5Pass;
                customer.CustomerID = id;
                bool res = cus.Update(id, customer);

                if (res)
                {
                    return RedirectToAction("Index", "Customer");
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

        // GET: Admin/Customer/Delete/5
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            if (new CustomerModel().Delete(id) == true)
                ModelState.AddModelError("", "Xóa thành công");
            else
                ModelState.AddModelError("", "Xóa thất bại");
            return RedirectToAction("Index", "Customer");
        }

        // POST: Admin/Customer/Delete/5
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
