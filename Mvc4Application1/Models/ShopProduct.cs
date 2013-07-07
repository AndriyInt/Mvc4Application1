using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc4Application1.Models
{
    public class ShopProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string ImageUrl { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, 1000000000)]
        public decimal Price { get; set; }

        [Required]
        public bool IsFeatured { get; set; }

        [Required]
        public bool IsPublished { get; set; }

        public virtual ICollection<ShopCategory> Categories { get; set; }

        ////public ShopProduct()
        ////{
        ////    this.Categories = new HashSet<ShopCategory>();
        ////}
    }
}