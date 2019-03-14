using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CategoryDAO
    {
        private PetShopDBContext db = null;
        public CategoryDAO()
        {
            db = new PetShopDBContext();
        }

        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
    }
}
