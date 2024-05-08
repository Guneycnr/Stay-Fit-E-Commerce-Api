using ApiBitirmeProjesi.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBitirmeProjesi.Models.Authentication.Configurations;

public class ContactConfiguration : CustomConfiguration<Contact, int>
{
    public override void Configure(EntityTypeBuilder<Contact> builder)
    {
        // Contact tablosundaki kolonlara koyulan kurallar

        base.Configure(builder);

        builder.Property(c => c.Name)
            .HasMaxLength(50);

        builder.Property(c => c.Email)
            .HasMaxLength(50);

        builder.Property(c => c.Message)
            .HasMaxLength(800);

        builder.Property(c => c.UpdatedDate)
            .ValueGeneratedOnUpdate();
    }
}