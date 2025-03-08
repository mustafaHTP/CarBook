using CarBook.Application.Dtos.ModelDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ModelValidators
{
    public class CreateModelDtoValidator : AbstractValidator<CreateModelDto>
    {
        public CreateModelDtoValidator()
        {
            RuleFor(x => x.BrandId)
                .NotEmpty();
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
