using Microsoft.EntityFrameworkCore;
using ShopHeo.Data.Entities;
using ShopHeo.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig { Key = "HomeTitle", Value = "This is HomePage HshopSolution" },
                new AppConfig { Key = "HomeKeyword", Value = "This KeyWord HshopSoltion" },
                new AppConfig { Key = "Home Description", Value = "This is Description HshopSolution" });
            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    Id = "vi-VN",
                    Name = "Tiếng Việt",
                    IsDefault = true,
                },
                new Language
                {
                    Id = "us-eng",
                    Name = "English",
                    IsDefault = false,
                }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    SortOder = 1,
                    ParentID = 2,
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    SortOder = 2,
                    ParentID = null,
                    Status = Status.Active,
                });
            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en", SeoAlias = "men-shirt", SeoDescription = "The shirt products for men", SeoTitle = "The shirt products for men" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang women" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en", SeoAlias = "women-shirt", SeoDescription = "The shirt products for women", SeoTitle = "The shirt products for women" }
                  );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Price = 90000,
                    OriginalPrice = 95000,
                    DateCreated = DateTime.Now,
                    Stock = 0,
                    ViewCount = 0,
                }
               );
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation
                {
                    Id = 1,
                    ProductId = 1,
                    Name = "Áo sơ mi nam trắng Việt Tiến",
                    LanguageId = "vi",
                    SeoAlias = "ao-so-mi-nam-trang-viet-tien",
                    SeoDescription = "Áo sơ mi nam trắng Việt Tiến",
                    SeoTitle = "Áo sơ mi nam trắng Việt Tiến",
                    Details = "Áo sơ mi nam trắng Việt Tiến",
                    Description = "Áo sơ mi nam trắng Việt Tiến"
                },
                new ProductTranslation
                {
                    Id = 2,
                    ProductId = 1,
                    Name = "Viet Tien Men T-Shirt",
                    LanguageId = "en",
                    SeoAlias = "viet-tien-men-t-shirt",
                    SeoDescription = "Viet Tien Men T-Shirt",
                    SeoTitle = "Viet Tien Men T-Shirt",
                    Details = "Viet Tien Men T-Shirt",
                    Description = "Viet Tien Men T-Shirt"
                }
                );
            modelBuilder.Entity<ProductInCategory>().HasData(
               new ProductInCategory() { ProductID = 1, CategoryID = 1 }
               );
        }
    }
}
