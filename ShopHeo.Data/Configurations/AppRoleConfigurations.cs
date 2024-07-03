using Microsoft.EntityFrameworkCore;
using ShopHeo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Configurations
{
    public class AppRoleConfigurations : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRoles");
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
        }
    }
}
