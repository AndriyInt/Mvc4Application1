﻿namespace Andriy.Mvc4Application1.Models
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
        
        public virtual ICollection<ShopCategory> Subcategories { get; set; }
        
        [Display(Name = "Parent Category")]
        public virtual ShopCategory ParentCategory { get; set; }

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

        public virtual ICollection<ShopProduct> Products { get; set; }
    }
}