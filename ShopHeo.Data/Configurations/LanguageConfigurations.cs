﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopHeo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Configurations
{
    public class LanguageConfigurations : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Language");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().IsUnicode(false).HasMaxLength(5);
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        }
    }
}
