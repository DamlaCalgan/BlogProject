using AutoMapper;
using DamlaProje.Blog.DTO.DTOs.BlogDtos;
using DamlaProje.Blog.DTO.DTOs.CategoryDtos;
using DamlaProje.Blog.DTO.DTOs.CommentDtos;
using DamlaProje.Blog.Entities.Concrete;
using DamlaProje.Blog.WebApi.Models;

namespace DamlaProje.Blog.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BlogListDto, DamlaProje.Blog.Entities.Concrete.Blog>();
            CreateMap<DamlaProje.Blog.Entities.Concrete.Blog, BlogListDto>();

            CreateMap<BlogUpdateModel, DamlaProje.Blog.Entities.Concrete.Blog>();
            CreateMap<DamlaProje.Blog.Entities.Concrete.Blog, BlogUpdateModel>();

            CreateMap<BlogAddModel, DamlaProje.Blog.Entities.Concrete.Blog>();
            CreateMap<DamlaProje.Blog.Entities.Concrete.Blog, BlogAddModel>();

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();

            CreateMap<Comment, CommentListDto>();
            CreateMap<CommentListDto, Comment>();

            CreateMap<Comment, CommentAddDto>();
            CreateMap<CommentAddDto, Comment>();


        }
    }
}
