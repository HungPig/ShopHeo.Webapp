using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopHeo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Configurations
{
    public class ProductInCategoryConfigurations : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(bc => new { bc.ProductID, bc.CategoryID });
            builder.ToTable("ProductInCategory");
            builder.HasOne(bc => bc.Product).WithMany(bc => bc.ProductInCategories)
                .HasForeignKey(bc => bc.ProductID);
            builder.HasOne(bc => bc.Category).WithMany(bc => bc.ProductInCategories)
                .HasForeignKey(bc => bc.CategoryID);
        }
    }
}
