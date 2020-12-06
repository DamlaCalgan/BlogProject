using DamlaProje.Blog.DataAccess.Interfaces;
using DamlaProje.Blog.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamlaProje.Blog.Business.Interfaces
{
    public interface IBlogDal : IGenericDal<DamlaProje.Blog.Entities.Concrete.Blog>
    {
        Task<List<DamlaProje.Blog.Entities.Concrete.Blog>> GetAllByCategoryIdAsync(int categoryId);
        Task<List<Category>> GetCategoriesAsync(int blogId);
        Task<List<DamlaProje.Blog.Entities.Concrete.Blog>> GetLastFiveAsync();
    }
}
