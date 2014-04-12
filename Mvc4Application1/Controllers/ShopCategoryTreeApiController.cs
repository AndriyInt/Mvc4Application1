namespace Andriy.Mvc4Application1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Andriy.Mvc4Application1.DTOs;
    using Andriy.Mvc4Application1.Models;

    public class ShopCategoryTreeApiController : ApiController
    {
        private readonly MovieDBContext db = new MovieDBContext();
        
        /// <summary>
        /// Returns root categories for aciTree jquery plugin
        /// 
        /// Sample request: GET api/shopcategorytreeapi
        /// </summary>
        /// <returns></returns>
        public IQueryable<AciTreeNode> Get()
        {
            return
                this.db.ShopCategories.Where(cat => cat.ParentCategory == null).Select(
                    cat => new AciTreeNode
                               {
                                   Id = string.Empty + cat.CategoryId, 
                                   Label = cat.Name,
                                   Inode = cat.Subcategories.Any()
                               });
        }

        // GET api/shopcategorytreeapi/5
        public IEnumerable<AciTreeNode> Get(int id)
        {
            var shopcategory = this.db.ShopCategories.Find(id);
            if (shopcategory == null)
            {
                return null;
            }

            return shopcategory.Subcategories.Select(
                    cat => new AciTreeNode
                               {
                                   Id = string.Empty + cat.CategoryId, 
                                   Label = cat.Name,
                                   Inode = cat.Subcategories.Any()
                               });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
