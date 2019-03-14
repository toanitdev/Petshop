using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models.Class
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Nhập User")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Nhập Password")]
        public string password { get; set; }

        public bool rememberMe { get; set; }
    }
}