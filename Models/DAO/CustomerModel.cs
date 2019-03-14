using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.DAO
{
    public class CustomerModel
    {
        PetShopDBContext db = null;

        public CustomerModel()
        {
            db = new PetShopDBContext();
        }
        public void Active(string id)
        {
            var cus = db.Customers.Find(id);
            cus.status = "ACTIVE";
            db.SaveChanges();
        }
        public List<Customer> GetList()
        {
            var list = db.Customers.ToList();
            return list;
        }
        public void Insert(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }
        public Customer GetCustomer(string id)
        {
            var cus = db.Customers.Find(id);
            return cus;
        }
      
        public bool Delete(string id)
        {
            try
            {
                db.Customers.Remove(db.Customers.Find(id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(string id,Customer customer)
        {
            try
            {
                var cus = db.Customers.Find(id);//6526263526263
                cus.CustomerID = customer.CustomerID;
                cus.Password = customer.Password;
                cus.LastName = customer.LastName;
                cus.FirstName = customer.FirstName;
                cus.Address = customer.Address;
                cus.Email = customer.Email;
                
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