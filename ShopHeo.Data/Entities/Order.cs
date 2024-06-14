using ShopHeo.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OderDate { get; set; }
        public int UserID { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public string ShipMobilePhone { get; set; }
        public OderStatus Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
