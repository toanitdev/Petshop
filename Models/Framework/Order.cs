namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public long OrderID { get; set; }

        [StringLength(32)]

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tài khoản")]
        public string CustomerID { get; set; }

        [StringLength(255)]

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Địa chỉ giao")]
        public string ShipAddress { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Email giao hàng")]
        public string ShipEmail { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        [Display(Name = "NV giao hàng")]
        public string Username { get; set; }

        [StringLength(50)]
        [Display(Name = "SĐT giao hàng")]
        public string sdt { get; set; }

        [StringLength(50)]
        [Display(Name = "Phương thức thanh toán")]
        public string method { get; set; }



    }
}
