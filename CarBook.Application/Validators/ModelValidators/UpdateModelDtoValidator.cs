using CarBook.Application.Dtos.ModelDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ModelValidators
{
    public class UpdateModelDtoValidator : AbstractValidator<UpdateModelDto>
    {
        public UpdateModelDtoValidator()
        {
            RuleFor(x => x.BrandId)
                .NotEmpty();
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
