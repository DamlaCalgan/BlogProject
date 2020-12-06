using DamlaProje.Blog.DTO.DTOs.CategoryBlogDtos;
using DamlaProje.Blog.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamlaProje.Blog.Business.Interfaces
{
    public interface IBlogService : IGenericService<DamlaProje.Blog.Entities.Concrete.Blog>
    {
        Task<List<DamlaProje.Blog.Entities.Concrete.Blog>> GetAllSortedByPostedTimeAsync();
        Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task<List<DamlaProje.Blog.Entities.Concrete.Blog>> GetAllByCategoryIdAsync(int categoryId);
        Task<List<Category>> GetCategoriesAsync(int blogId);
        Task<List<Entities.Concrete.Blog>> GetLastFiveAsync();
        Task<List<Entities.Concrete.Blog>> SearchAsync(string searchString);
    }
}
