using DamlaProje.Blog.DTO.Interfaces;

namespace DamlaProje.Blog.DTO.DTOs.AppUserDtos
{
    public class AppUserLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
