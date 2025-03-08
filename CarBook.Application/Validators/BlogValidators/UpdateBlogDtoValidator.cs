using CarBook.Application.Dtos.BlogDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.BlogValidators
{
    public class UpdateBlogDtoValidator : AbstractValidator<UpdateBlogDto>
    {
        public UpdateBlogDtoValidator()
        {
            RuleFor(x => x.BlogAuthorId)
                .NotEmpty();
            RuleFor(x => x.BlogCategoryId)
                .NotEmpty();
            RuleFor(x => x.Content)
                .NotEmpty();
            RuleFor(x => x.CoverImageUrl)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
            RuleFor(x => x.Title)
                .NotEmpty();
        }
    }
}
