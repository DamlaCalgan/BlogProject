using DamlaProje.Blog.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamlaProje.Blog.DataAccess.Interfaces
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        Task<List<Category>> GetAllWithCategoryBlogsAsync();
    }
}
