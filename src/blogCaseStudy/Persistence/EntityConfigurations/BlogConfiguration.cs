using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Blogs").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Title).HasColumnName("Title");
        builder.Property(b => b.Context).HasColumnName("Context");
        builder.Property(b => b.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(b => b.UserId).HasColumnName("UserId");
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(p => p.Comments);


        builder.HasOne(p => p.User)
                .WithMany(p => p.Blogs)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}