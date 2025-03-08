using CarBook.Application.Dtos.BlogTagCloudDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.BlogTagCloudValidators
{
    public class CreateTagCloudDtoValidator : AbstractValidator<CreateBlogTagCloudDto>
    {
        public CreateTagCloudDtoValidator()
        {
            RuleFor(x => x.BlogTagId)
                .NotEmpty();
            RuleFor(x => x.BlogId)
                .NotEmpty();
        }
    }
}
