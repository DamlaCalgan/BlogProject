using DamlaProje.Blog.DTO.DTOs.AppUserDtos;
using DamlaProje.Blog.Entities.Concrete;
using System.Threading.Tasks;

namespace DamlaProje.Blog.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto);
        Task<AppUser> FindByNameAsync(string userName);
    }
}
