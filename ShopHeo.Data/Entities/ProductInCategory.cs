using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Entities
{
    public class ProductInCategory
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
