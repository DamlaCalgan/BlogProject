using DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using DamlaProje.Blog.DataAccess.Interfaces;
using DamlaProje.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDal
    {
        private readonly BlogContext _context;
        public EfCategoryRepository(BlogContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllWithCategoryBlogsAsync()
        {
            return await _context.Categories.OrderByDescending(I=>I.Id).Include(I => I.CategoryBlogs).ToListAsync();
        }
    }
}
