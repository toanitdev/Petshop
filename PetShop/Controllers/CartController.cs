
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.DAO;
using Models.Framework;
using PetShop.Common;

namespace PetShop.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";

        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = (List<PetShop.Models.CartItem>)cart;
            if (cart != null)
            {
                list = (List<PetShop.Models.CartItem>)cart;
            }

            return View(list);
        }
        //Đặt hàng
        public ActionResult dathang()
        {
            var cart = Session[CartSession];
            if (cart == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (Session[Common.CommonConstants.CUSTOMER_SESSION] == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    return View();
                }
            }
        }

        //Đặt hàng
        [HttpPost]
        public ActionResult dathang(Order orders)
        {
            var cart = Session[CartSession];
            if (cart != null)
            {
                OrderModel model = new OrderModel();
                orders.CustomerID = ((UserLogin)Session[Common.CommonConstants.CUSTOMER_SESSION]).UserName;
                orders.Status = 1;
                Order order = model.Insert(orders);
                List<OrderDetail> list = new List<OrderDetail>();
                foreach (PetShop.Models.CartItem item in ((List<PetShop.Models.CartItem>)cart))
                {
                    OrderDetail o = new OrderDetail();
                    o.Quantity = item.Quantity;
                    o.Price = item.Product.Price;
                    o.ProductID = item.Product.ID;
                    o.Order = order.OrderID;
                    list.Add(o);
                }
                new OrderDetailsModel().InsertList(list);
                Customer customer = new CustomerModel().GetCustomer(order.CustomerID);
                List<Models.CartItem> lm = new List<Models.CartItem>();
                lm = (List<Models.CartItem>)cart;
                MailService mail = new MailService();
                mail.SendMail(mail.MailOrder(customer, order, lm),customer.Email);
                Session[CartSession] = null;


            }
            return RedirectToAction("Step1", "Cart");
        }

        public ActionResult AddItem(int productID, int quantity)
        {
            var product = new ProductModel().ViewDetail(productID);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<PetShop.Models.CartItem>)cart;

                if (list.Exists(c => c.Product.ID == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new PetShop.Models.CartItem();
                    item.Product = product;
                    item.Quantity = quantity;

                    list.Add(item);


                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new PetShop.Models.CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<PetShop.Models.CartItem>();
                list.Add(item);

                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public ActionResult step1(){ return View(); }
    }
}