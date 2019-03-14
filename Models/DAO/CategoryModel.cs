using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Models.DAO
{
    public class CategoryModel
    {
        private PetShopDBContext context = null;

        public CategoryModel(){
            context = new PetShopDBContext();
        }
        public List<Category> ListAll()
        {
            var list = context.Database.SqlQuery<Category>("uspCategoryList").ToList();
            return list;
        }

       
        public int Delete(int ID)
        {
            int res = context.Database.ExecuteSqlCommand("uspDelCategoryByID @id",new SqlParameter("@id", ID));
            return res;
        }

        public void Create(Category category) {

            context.Categories.Add(category);
            context.SaveChanges();
           
        }
        public Category GetCategory(int id) {
            return context.Categories.Find(id);

        }
        public void Update(long id, Category category)
        {
            var cate = context.Categories.Find(category.ID);
            cate.Name = category.Name;
            cate.Alias = category.Alias;
            cate.Status = category.Status;
            context.SaveChanges();
        }
    }
}