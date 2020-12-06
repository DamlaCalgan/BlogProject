using DamlaProje.Blog.DTO.DTOs.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamlaProje.Blog.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Parola alanı  boş geçilemez");
        }
    }
}
