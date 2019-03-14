using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.DAO
{ 
    public class OrderModel
    {
        PetShopDBContext db = null;

        public OrderModel()
        {
            db = new PetShopDBContext();
        }

        public List<Order> GetList()
        {
            var list = db.Orders.ToList();
            return list;
        }
        public List<Order> GetListByShip(string user)
        {
            var list = db.Orders.Where(x=>x.Username == user).ToList();
            return list;
        }
        public List<Order> GetListByCustomer(string id)
        {
            var list = db.Orders.Where(x => x.CustomerID == id).ToList();
            return list;
        }
        public Order Insert(Order order)
        {
            Order o = db.Orders.Add(order);
            db.SaveChanges();
            return o;

        }
        public void Delete(long id) {
            var order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
        }
        public Order GetOrder(long id)
        {
            return db.Orders.Find(id);
        }
        public bool Update(long id, Order order)
        {
            try
            {
                var or = db.Orders.Find(id);
                or.CustomerID= order.CustomerID;
                or.ShipAddress = order.ShipAddress;
                or.ShipEmail = order.ShipEmail;
                or.Username = order.Username;
                or.Status = order.Status;
                or.method = order.method;
                or.sdt = order.sdt;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}