using CarBook.Application.Dtos.BlogCategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.BlogCategoryValidators
{
    public class UpdateBlogCategoryDtoValidator : AbstractValidator<UpdateBlogCategoryDto>
    {
        public UpdateBlogCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
