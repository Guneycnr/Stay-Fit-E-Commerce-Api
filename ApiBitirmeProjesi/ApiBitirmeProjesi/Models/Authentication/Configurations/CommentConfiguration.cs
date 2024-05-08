using ApiBitirmeProjesi.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBitirmeProjesi.Models.Authentication.Configurations;

public class CommentConfiguration : CustomConfiguration<Comment, int>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        // Comment tablosundaki kolona koyulan kurallar

        base.Configure(builder);

        builder.Property(c => c.CommentLine)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(c => c.UpdatedDate)
            .ValueGeneratedOnUpdate();
    }
}