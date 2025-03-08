using CarBook.Application.Dtos.FeatureDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.FeatureValidators
{
    public class UpdateFeatureDtoValidator : AbstractValidator<UpdateFeatureDto>
    {
        public UpdateFeatureDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
