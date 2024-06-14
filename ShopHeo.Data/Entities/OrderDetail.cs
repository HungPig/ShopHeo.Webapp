using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Entities
{
    public class OrderDetail
    {
        public int OrderID{ get; set; }
        public int ProductID { get; set; }
        public string Quantity { get; set; }
        public int Price { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
