using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UserDAO
    {
        PetShopDBContext db = null;
        public UserDAO()
        {
            db = new PetShopDBContext();

        }

        public string Insert(Account entity)
        {
            db.Accounts.Add(entity);
            db.SaveChanges();
            return entity.Username;
        }

        public bool Update(Account entity)
        {
            try
            {
                var user = db.Accounts.Find(entity.Username);
                user.Password = entity.Password;
                user.title = entity.title;
                db.SaveChanges();    
                return true;
            } catch(Exception ex)
            {
                return false;
            }
          
        }
        public bool Delete(string username)
        {
            try
            {
                var user = db.Accounts.Find(username);
                db.Accounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public Account GetAccount(string userName)
        {
            var res = db.Accounts.SingleOrDefault(x => x.Username == userName);
            return res;
        }
        public List<Account> GetAccountList()
        {
            var res = db.Accounts.ToList<Account>();
            return res;
        }
        public bool Login(string userName , string password)
        {
            var res = db.Accounts.Count(x => x.Username == userName && x.Password == password);
            if (res >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LoginShipper(string userName, string password)
        {
            var res = db.Accounts.Count(x => x.Username == userName && x.Password == password&&x.title =="01");
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
