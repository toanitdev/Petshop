namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [StringLength(32)]

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tài khoản")]
        public string CustomerID { get; set; }

        [StringLength(32)]

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Họ")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không được để trống")]
        public string Email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không được để trống")]
        public string sdt { get; set; }

        [StringLength(50)]
        public string status { get; set; }
    }
}
