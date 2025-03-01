using CarBook.Application.Dtos.CarReviewDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.CarReviewValidators
{
    public class CreateCarReviewDtoValidator : AbstractValidator<CreateCarReviewDto> 
    {
        public CreateCarReviewDtoValidator()
        {
            RuleFor(x => x.CarId)
                .NotEmpty();
            RuleFor(x => x.CustomerId)
                .NotEmpty();
            RuleFor(x => x.Review)
                .NotEmpty()
                .MaximumLength(500);
            RuleFor(x => x.ReviewDate)
                .NotEmpty();
            RuleFor(x => x.RatingStarCount)
                .InclusiveBetween(0, 5);
        }
    }
}
