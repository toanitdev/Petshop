namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(50)]

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [StringLength(50)]
        public string Alias { get; set; }

        [Display(Name = "Loại hàng")]
        public int? Category { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public DateTime? CreateDate { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Giá")]
        public decimal? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }
        
        [Display(Name = "Tình trạng")]
        public bool? Status { get; set; }
    }
}
