namespace Andriy.Mvc4Application1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class ShopCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        ////public Nullable<int> ParentCategoryId { get; set; }
        
        public ICollection<ShopCategory> Subcategories { get; set; }
        
        [Display(Name = "Parent Category")]
        public ShopCategory ParentCategory { get; set; }

        public string Path
        {
            get
            {
                var hierarchy = new LinkedList<ShopCategory>();
                for (var t = this; t != null; t = t.ParentCategory)
                {
                    hierarchy.AddFirst(t);
                }

                return string.Join("/", hierarchy.Select(c => c.Name));
            }
        }

        public ICollection<ShopProduct> Products { get; set; }

        ////public ShopCategory()
        ////{
        ////    this.Subcategories = new HashSet<ShopCategory>();
        ////    this.Products = new HashSet<ShopProduct>();
        ////}
    }
}