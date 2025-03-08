using CarBook.Application.Dtos.BlogAuthorDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.BlogAuthorValidators
{
    public class UpdateBlogAuthorDtoValidator : AbstractValidator<UpdateBlogAuthorDto>
    {
        public UpdateBlogAuthorDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
            RuleFor(x => x.ImageUrl)
                .NotEmpty();
        }
    }
}
