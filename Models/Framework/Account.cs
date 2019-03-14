namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(50)]
        
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [StringLength(50)]

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã cấp quyền")]
        public string title { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "SĐT")]
        public string PhoneNumber { get; set; }
    }
}
