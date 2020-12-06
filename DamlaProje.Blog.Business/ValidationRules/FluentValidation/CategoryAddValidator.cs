using DamlaProje.Blog.DTO.DTOs.CategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamlaProje.Blog.Business.ValidationRules.FluentValidation
{
    public class CategoryAddValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        }
    }
}
