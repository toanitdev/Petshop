
using Models.Class;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.DAO
{
    public class OrderDetailsModel
    {
        PetShopDBContext db = null;

        public OrderDetailsModel() {
            db = new PetShopDBContext();
        }

        public List<OrderDetails> GetDetailsByOrderID(long id)
        {
            var list = (from od in db.OrderDetails
                        join p in db.Products
                        on od.ProductID equals p.ID
                        where od.Order == id
                        select new
                        {
                            Name = p.Name,
                            Price = p.Price,
                            Quantity = od.Quantity,
                            Sum = od.Quantity * p.Price
                        }
                       ).ToList();
            List<OrderDetails> l = new List<OrderDetails>();
            foreach (var item in list)
            {
                OrderDetails order = new OrderDetails();
                order.name = item.Name.ToString();
                order.price = item.Price.ToString();
                order.quantity = item.Quantity.ToString();
                order.sum = (double)(item.Sum);
                l.Add(order);
            }
            return l;

        }
        public void InsertList (List<OrderDetail> list)
        {
            foreach (OrderDetail item in list)
            {
                db.OrderDetails.Add(item);
                db.SaveChanges();
            }
           
        }

    }
}