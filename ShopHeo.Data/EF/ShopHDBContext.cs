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
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CategoryTranslation> categoryTranslations { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<ProductTranslation> productTranslations { get; set; }
        public DbSet<Promotion> promotion { get; set; }
        public DbSet<Transaction> transaction { get; set; }
        public ShopHDBContext(DbContextOptions options) : base(options)
        {
        }

    }
}
