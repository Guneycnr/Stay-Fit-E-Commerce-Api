using ApiBitirmeProjesi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBitirmeProjesi.Models.Authentication.Configurations;

public class ProductConfiguration : CustomConfiguration<Product, int>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        // Product tablosundaki kolonlara koyulan kurallar

        base.Configure(builder);

        builder.Property(p => p.ProductName)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(p => p.UnitPrice)
            .IsRequired()
            .HasColumnType("money");

        builder.Property(p => p.UnitStock)
            .IsRequired();

        builder.Property(p => p.UpdatedDate)
            .ValueGeneratedOnUpdate();
    }
}
