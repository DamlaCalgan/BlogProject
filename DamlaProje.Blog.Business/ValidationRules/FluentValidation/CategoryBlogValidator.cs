using DamlaProje.Blog.DTO.DTOs.CategoryBlogDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamlaProje.Blog.Business.ValidationRules.FluentValidation
{
    public class CategoryBlogValidator : AbstractValidator<CategoryBlogDto>
    {
        public CategoryBlogValidator()
        {
            RuleFor(I => I.CategoryId).InclusiveBetween(0,int.MaxValue).WithMessage("CategoryId boş geçilemez");
            RuleFor(I => I.BlogId).InclusiveBetween(0,int.MaxValue).WithMessage("BlogId boş geçilemez");
        }
    }
}
