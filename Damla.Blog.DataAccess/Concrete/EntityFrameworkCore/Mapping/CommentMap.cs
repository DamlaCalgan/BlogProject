using DamlaProje.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.AuthorName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.AuthorEmail).HasMaxLength(300).IsRequired();
            builder.Property(I => I.Description).HasMaxLength(400).IsRequired();

            builder.HasOne(I => I.ParentComment).WithMany(I => I.SubComments).HasForeignKey(I => I.ParentCommentId);
        }
    }
}
