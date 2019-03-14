using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            var product = new ProductModel();
            var list = product.GetList();
            return View(list);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            SetViewBag();
            if (ModelState.IsValid)
            {
                var pro = new ProductModel();
                pro.Insert(product);

                return RedirectToAction("Index", "Product");
            }
            else
            {


            }
            return View();
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(long id)
        {
            var res = new ProductModel().GetProduct(id);
            SetViewBag();

            return View(res);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit( long id ,Product product)
        {
            try
            {
                SetViewBag();
                new ProductModel().Update(id,product);

                return RedirectToAction("Index","Product");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                new ProductModel().Delete(id);
                return RedirectToAction("Index","Product");

            }
            catch
            {
                return View();
            }
    }


        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDAO();
            ViewBag.Category = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
    }
}
