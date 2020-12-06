using DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using DamlaProje.Blog.DataAccess.Interfaces;
using DamlaProje.Blog.Entities.Concrete;

namespace DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserRepository(BlogContext context) : base(context) 
        {
        }
        
    }
}
