using CarBook.Application.Dtos.BlogTagDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.BlogTagValidators
{
    public class UpdateBlogTagDtoValidator : AbstractValidator<UpdateBlogTagDto>
    {
        public UpdateBlogTagDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
