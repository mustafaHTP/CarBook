using CarBook.Application.Dtos.FeatureDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.FeatureValidators
{
    public class CreateFeatureDtoValidator : AbstractValidator<CreateFeatureDto>
    {
        public CreateFeatureDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
