using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var eplCate = new CategoryModel();
            var model = eplCate.ListAll();

            return View(model);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(Category collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    var model = new CategoryModel();
                    try { 
                        model.Create(collection);
                    }
                    catch{
                        ModelState.AddModelError("", "Thêm mới không thành công");
                    }
                }
                return RedirectToAction("Index", "Category");

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(new CategoryModel().GetCategory(id));
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(long id, Category category)
        {
            try
            {
                // TODO: Add update logic here
                new CategoryModel().Update(id, category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CategoryModel().Delete(id);
            return RedirectToAction("Index", "Category");
        }

        // POST: Admin/Category/Delete/5
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
