using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Application.CataLog.Products.Dtos.Manage
{
    public interface ProductViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; } // co phieu
        public int ViewCount { get; set; } // xem co phieu
        public DateTime DateCreated { get; set; } // ngay tao ra
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
    }
}
