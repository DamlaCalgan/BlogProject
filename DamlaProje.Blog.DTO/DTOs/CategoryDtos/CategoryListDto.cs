using DamlaProje.Blog.DTO.Interfaces;

namespace DamlaProje.Blog.DTO.DTOs.CategoryDtos
{
    public class CategoryListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
