using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Entities
{
    public class OrderDetails
    {
        public int OrderID{ get; set; }
        public int ProductID { get; set; }
        public string Quantity { get; set; }
        public int Price { get; set; }
    }
}
