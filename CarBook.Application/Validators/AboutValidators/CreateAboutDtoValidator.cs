using CarBook.Application.Dtos.AboutDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.AboutValidators
{
    public class CreateAboutDtoValidator : AbstractValidator<CreateAboutDto>
    {
        public CreateAboutDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
            RuleFor(x => x.ImageUrl)
                .NotEmpty();
        }
    }
}
