using DamlaProje.Blog.Business.Concrete;
using DamlaProje.Blog.Business.Interfaces;
using DamlaProje.Blog.Business.Tools.FacadeTool;
using DamlaProje.Blog.Business.Tools.JWTTool;
using DamlaProje.Blog.Business.Tools.LogTool;
using DamlaProje.Blog.Business.ValidationRules.FluentValidation;
using DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using DamlaProje.Blog.DataAccess.Interfaces;
using DamlaProje.Blog.DTO.DTOs.AppUserDtos;
using DamlaProje.Blog.DTO.DTOs.CategoryBlogDtos;
using DamlaProje.Blog.DTO.DTOs.CategoryDtos;
using DamlaProje.Blog.DTO.DTOs.CommentDtos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DamlaProje.Blog.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<BlogContext>();

            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentRepository>();

            services.AddScoped<IJwtService, JwtManager>();
            services.AddScoped<ICustomLogger, NLogAdapter>();
            services.AddScoped<IFacade, Facade>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryBlogDto>, CategoryBlogValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
            services.AddTransient<IValidator<CommentAddDto>, CommentAddValidator>();
        }
    }
}
