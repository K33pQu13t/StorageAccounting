using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageAccounting.Domain.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAccounting.Domain.Configurations.StorageAccounting;
internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder
            .ToTable(schema: "STORAGE", name: "INVOICE")
            .ToTable(t =>
            {
                t.HasComment("Документ накладной");
            });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DocumentId).HasColumnName("ID_DOCUMENT");

        builder
            .HasOne(x => x.Document)
            .WithMany(x => x.Invoices);
    }
}
