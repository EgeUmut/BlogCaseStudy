using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Context).HasColumnName("Context");
        builder.Property(c => c.UserId).HasColumnName("UserId");
        builder.Property(c => c.BlogId).HasColumnName("BlogId");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(c => c.User)
               .WithMany(u => u.Comments)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Blog)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.BlogId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}