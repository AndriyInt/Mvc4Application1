namespace Andriy.Mvc4Application1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShopCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        ////public Nullable<int> ParentCategoryId { get; set; }
        public virtual ICollection<ShopCategory> Subcategories { get; set; }
        //public virtual ShopCategory ParentCategory { get; set; }
        public virtual ICollection<ShopProduct> Products { get; set; }

        ////public ShopCategory()
        ////{
        ////    this.Subcategories = new HashSet<ShopCategory>();
        ////    this.Products = new HashSet<ShopProduct>();
        ////}
    }
}