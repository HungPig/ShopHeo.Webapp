using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopHeo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Configurations
{
    public class OrderDeltailsConfigurations : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasKey(bc => new {bc.OrderID, bc.ProductID });
            builder.HasOne(bc => bc.Order).WithMany(bc => bc.OrderDetails).HasForeignKey(bc => bc.OrderID);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(t => t.ProductID);
        }
    }
}
