using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Application.Catalog.Products.Dtos
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; } 

        public string Name { get; set; } 
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
    }
}
