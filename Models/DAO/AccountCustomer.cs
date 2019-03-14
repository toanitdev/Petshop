using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Models.DAO
{
    public class AccountCustomer
    {
        PetShopDBContext db = null;

        public AccountCustomer()
        {
            db = new PetShopDBContext();
        }

        public void Create(Customer customer)
        {
            customer.status = "none";
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public Customer GetCustomer(string username)
        {
            var cus = db.Customers.Find(username);
            return cus;
        }

        public bool Login(string userName, string password)
        {
            object[] param = {
                new SqlParameter("@Username",userName),
                new SqlParameter("@Password",password)
            };
            var res = db.Database.SqlQuery<bool>("Sp_Account_Customer_Login @Username,@Password", param).SingleOrDefault();
            return res;
        }
    }
}