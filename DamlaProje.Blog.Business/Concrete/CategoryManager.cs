using DamlaProje.Blog.Business.Interfaces;
using DamlaProje.Blog.DataAccess.Interfaces;
using DamlaProje.Blog.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamlaProje.Blog.Business.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly IGenericDal<Category> _genericDal;
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(IGenericDal<Category> genericDal, ICategoryDal categoryDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _categoryDal = categoryDal;
        }

        public async Task<List<Category>> GetAllSortedByIdAsync()
        {
            return await _genericDal.GetAllAsync(I => I.Id);
        }

        public async Task<List<Category>> GetAllWithCategoryBlogsAsync()
        {
            return await _categoryDal.GetAllWithCategoryBlogsAsync();
        }
    }
}
