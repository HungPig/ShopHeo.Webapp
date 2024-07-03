using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Entities
{
    public class AppUser : IdentityUser<Guid> // guild ở đây duy nhất toàn hệ thống
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
