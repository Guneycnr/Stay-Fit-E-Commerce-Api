using ApiBitirmeProjesi.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiBitirmeProjesi.Models.Authentication.Configurations;

public class CustomConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
     where TEntity : BaseEntity<TKey>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // BaseEntity tablosundaki kolonlara koyulan kurallar

        builder.HasKey(x => x.Id);

        builder.Property(x => x.IsDeleted)
        .HasDefaultValue(false);

        builder.Property(x => x.CreatedDate)
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(x => x.UpdatedDate)
            .ValueGeneratedOnUpdate();
    }
}
