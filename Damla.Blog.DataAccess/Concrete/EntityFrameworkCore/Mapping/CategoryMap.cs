using DamlaProje.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();
            builder.HasMany(I => I.CategoryBlogs).WithOne(I => I.Category).HasForeignKey(I => I.CategoryId);
        }
    }
}
