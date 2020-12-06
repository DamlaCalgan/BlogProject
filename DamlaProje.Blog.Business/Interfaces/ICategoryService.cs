using DamlaProje.Blog.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamlaProje.Blog.Business.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<List<Category>> GetAllSortedByIdAsync();
        Task<List<Category>> GetAllWithCategoryBlogsAsync();
    }
}
