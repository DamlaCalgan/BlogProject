using DamlaProje.Blog.Business.Interfaces;
using DamlaProje.Blog.DataAccess.Interfaces;
using DamlaProje.Blog.DTO.DTOs.AppUserDtos;
using DamlaProje.Blog.Entities.Concrete;
using System.Threading.Tasks;

namespace DamlaProje.Blog.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto)
        {
            return await _genericDal.GetAsync(I=>I.UserName == appUserLoginDto.UserName && I.Password==appUserLoginDto.Password);
        }

        public async  Task<AppUser> FindByNameAsync(string userName)
        {
            return  await _genericDal.GetAsync(I => I.UserName == userName);
        }
    }
}
