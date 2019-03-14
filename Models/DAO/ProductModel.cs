using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.DAO
{
    public class ProductModel
    {
        PetShopDBContext db = null;

        public ProductModel()
        {
            db = new PetShopDBContext();
        }

        public List<Product> GetList() {
            var list = db.Products.ToList();
            return list;
        }
        
        public bool Delete(int id)
        {
            try
            {
                db.Products.Remove(db.Products.Find(id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public void Update(long id,Product product)
        {
            var pro = db.Products.Find(id);
            pro.Name = product.Name;
            pro.Alias = product.Alias;
            pro.Image = product.Image;
            pro.Category = product.Category;
            pro.Price = product.Price;
            db.SaveChanges();
        }
        public void Insert(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
        public Product GetProduct(long id)
        {
            var res = db.Products.SingleOrDefault(x=>x.ID == id);
            return res;
        }

        public Product ViewDetail(long productID)
        {
            var product = db.Products.Find(productID);
            return product;
        }
        public List<Product> ListProduct()
        {
            var list = db.Products.ToList();
            return list;
        }
    }
}