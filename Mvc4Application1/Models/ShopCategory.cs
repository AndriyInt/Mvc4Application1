namespace Andriy.Mvc4Application1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using Newtonsoft.Json;

    public class ShopCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<ShopCategory> Subcategories { get; set; }

        [JsonIgnore]
        [Display(Name = "Parent Category")]
        public virtual ShopCategory ParentCategory { get; set; }

        [JsonIgnore]
        [Display(Name = "Parent Category")]
        [NotMapped]
        public string ParentCategoryPath
        {
            get
            {
                return this.ParentCategory == null
                           ? "<None>"
                           : this.ParentCategory.Path;
            }
        }

        [JsonIgnore]
        [Display(Name = "Full Path")]
        [NotMapped]
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

        [JsonIgnore]
        public virtual ICollection<ShopProduct> Products { get; set; }
    }
}