using ApiBitirmeProjesi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBitirmeProjesi.Models.Authentication.Configurations;

public class OrderConfiguration : CustomConfiguration<Order, int>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        // Order tablosundaki kolonlara koyulan kurallar

        base.Configure(builder);

        builder.Property(o => o.OrderDate)
            .IsRequired()
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(o => o.TotalPrice)
            .IsRequired()
            .HasColumnType("money");

        builder.Property(o => o.UpdatedDate)
            .ValueGeneratedOnUpdate();
    }
}
