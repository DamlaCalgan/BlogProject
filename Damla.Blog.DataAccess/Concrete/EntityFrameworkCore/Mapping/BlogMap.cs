using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class BlogMap : IEntityTypeConfiguration<DamlaProje.Blog.Entities.Concrete.Blog>
    {
        public void Configure(EntityTypeBuilder<Entities.Concrete.Blog> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Title).HasMaxLength(100).IsRequired();
            builder.Property(I => I.ShortDescription).HasMaxLength(300).IsRequired();
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(I => I.ImagePath).HasMaxLength(300);

            builder.HasMany(I => I.Comments).WithOne(I => I.Blog).HasForeignKey(I => I.BlogId);
            builder.HasMany(I => I.CategoryBlogs).WithOne(I => I.Blog).HasForeignKey(I => I.BlogId);
        }
    }
}
