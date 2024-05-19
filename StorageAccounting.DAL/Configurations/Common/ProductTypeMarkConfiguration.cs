﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.DAL.Models.Common;

namespace StorageAccounting.DAL.Configurations.Common;
internal class ProductTypeMarkConfiguration : IEntityTypeConfiguration<ProductTypeMark>
{
    public void Configure(EntityTypeBuilder<ProductTypeMark> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.ProductType)
            .WithMany(x => x.ProductTypeMarks);

        builder
            .HasOne(x => x.Mark)
            .WithMany(x => x.ProductTypeMarks);
    }
}