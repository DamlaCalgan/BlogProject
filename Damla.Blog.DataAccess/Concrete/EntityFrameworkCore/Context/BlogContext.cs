using DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using DamlaProje.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class BlogContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public BlogContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("db1"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new BlogMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CategoryBlogMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<DamlaProje.Blog.Entities.Concrete.Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
