using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopHeo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ShipName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ShipAddress).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ShipEmail).IsRequired().HasMaxLength(50);
        }
    }
}
