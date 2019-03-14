﻿using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AccountModel
    {


        private PetShopDBContext context = null;

        public AccountModel()
        {
            context = new PetShopDBContext();
        }

        public bool Login(string userName, string password)
        {
            object[] param = {
                new SqlParameter("@Username",userName),
                new SqlParameter("@Password",password)
            };
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login @Username,@Password",param).SingleOrDefault();
            return res;
        }
    }
}
