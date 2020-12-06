using DamlaProje.Blog.DTO.DTOs.CommentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamlaProje.Blog.Business.ValidationRules.FluentValidation
{
    public class CommentAddValidator :AbstractValidator<CommentAddDto>
    {
        public CommentAddValidator()
        {
            RuleFor(I => I.AuthorName).NotEmpty().WithMessage("Ad alanı boş bırakılamaz");    
            RuleFor(I => I.AuthorEmail).NotEmpty().WithMessage("Ad alanı boş bırakılamaz");    
            RuleFor(I => I.Description).NotEmpty().WithMessage("Ad alanı boş bırakılamaz");    
        }
    }
}
