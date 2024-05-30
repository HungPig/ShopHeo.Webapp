using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopHeo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.EF
{
    public class ShopHDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ShopHDBContext(DbContextOptions options) : base(options)
        {
        }

    }
}
