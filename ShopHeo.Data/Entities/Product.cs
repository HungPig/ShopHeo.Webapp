using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Entities
{
    public class Product
    {
      public int Id { get; set; }
      public decimal Price { get; set; }
      public decimal OriginalPrice { get; set; }
      public int Stock {  get; set; } // co phieu
      public int ViewCount { get; set; } // xem co phieu
      public DateTime DateCreated { get; set; } // ngay tao ra
      public int SeoAlias { get; set; }
      public List<ProductInCategory> ProductInCategories { get; set; }
      public List<OrderDetail> OrderDetails { get; set; }
      public List<ProductTranslation> ProductTranslations { get; set; }
    }
}
