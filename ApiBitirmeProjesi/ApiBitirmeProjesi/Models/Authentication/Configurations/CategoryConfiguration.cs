using ApiBitirmeProjesi.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBitirmeProjesi.Models.Authentication.Configurations;

public class CategoryConfiguration : CustomConfiguration<Category, int>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        // Category tablosundaki kolonlara koyulan kurallar

        base.Configure(builder);

        builder.Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(40);

        builder.Property(c => c.UpdatedDate)
            .ValueGeneratedOnUpdate();
    }
}
