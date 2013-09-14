namespace Andriy.Mvc4Application1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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

        [Display(Name = "Image")]
        public string DisplayImageURL
        {
            get
            {
                return string.IsNullOrEmpty(this.ImageUrl) ? Consts.DisplayImageURLDefault : this.ImageUrl;
            }
        }

        ////public ShopProduct()
        ////{
        ////    this.Categories = new HashSet<ShopCategory>();
        ////}
    }
}