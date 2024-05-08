using ApiBitirmeProjesi.Models.Authentication;
using ApiBitirmeProjesi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;
using System.Reflection.Emit;

namespace ApiBitirmeProjesi.Models.Authentication.Configurations;

public class AppUserConfiguration
{
    public virtual void Configure(EntityTypeBuilder<AppUser> builder)
    {
        // AppUser tablosundaki kolonlara koyulan kurallar

        builder.Property(c => c.Role)
            .HasDefaultValue(1);

        builder.Property(c => c.Adres)
            .IsRequired();

        builder.Property(c => c.City)
            .IsRequired();

        builder.Property(c => c.Country)
            .IsRequired();
    }
}

