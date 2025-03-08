using CarBook.Application.Dtos.SocialMediaDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.SocialMediaValidators
{
    public class CreateSocialMediaDtoValidator : AbstractValidator<CreateSocialMediaDto>
    {
        public CreateSocialMediaDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Url)
                .NotEmpty();
            RuleFor(x => x.Icon)
                .NotEmpty();
        }
    }
}
