using ApiBitirmeProjesi.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBitirmeProjesi.Models.Authentication.Configurations;

public class ShipperConfiguration : CustomConfiguration<Shipper, int>
{
    public override void Configure(EntityTypeBuilder<Shipper> builder)
    {
        // Shipper tablosundaki kolonlara koyulan kurallar

        base.Configure(builder);

        builder.Property(s => s.CompanyName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.Phone)
            .IsRequired();
        builder.HasIndex(s => s.Phone)
            .IsUnique();

        builder.Property(s => s.UpdatedDate)
            .ValueGeneratedOnUpdate();
    }
}
