using CarBook.Application.Dtos.CarReviewDtos;
using FluentValidation;

namespace CarBook.Application.Validators.CarReviewValidators
{
    public class UpdateCarReviewDtoValidator : AbstractValidator<UpdateCarReviewDto>
    {
        public UpdateCarReviewDtoValidator()
        {
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
