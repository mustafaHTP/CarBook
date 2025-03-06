using CarBook.WebApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.WebApp.Validators.SmartBookValidators
{
    public class CreateCarRecommendationDtoValidator : AbstractValidator<CreateCarRecommendationViewModel>
    {
        public CreateCarRecommendationDtoValidator()
        {
            RuleFor(cr => cr.UserInput)
                .NotEmpty()
                .WithMessage("You should provide prompt!");
        }
    }
}
