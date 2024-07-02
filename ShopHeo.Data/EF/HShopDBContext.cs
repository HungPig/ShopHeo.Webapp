using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopHeo.Data.Configurations;
using ShopHeo.Data.Entities;
using ShopHeo.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.EF
{
    public class HShopDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public HShopDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //FluentAPI
            modelBuilder.ApplyConfiguration(new AppConfigConfigurations());
            modelBuilder.ApplyConfiguration(new CartConfigurations());
            modelBuilder.ApplyConfiguration(new ProductConfigurations());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new OrderConfigurations());

            modelBuilder.ApplyConfiguration(new OrderDeltailsConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfigurations());
            modelBuilder.ApplyConfiguration(new ContactConfiguations());
            modelBuilder.ApplyConfiguration(new LanguageConfigurations());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfigurations());
            modelBuilder.ApplyConfiguration(new PromotionConfigurations());
            modelBuilder.ApplyConfiguration(new TransactionConfigurations());
            //Data Sending
            modelBuilder.Seed();
        }

    }
}
