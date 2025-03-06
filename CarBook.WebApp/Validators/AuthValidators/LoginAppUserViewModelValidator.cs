using CarBook.WebApp.Models.AuthModels;
using FluentValidation;

namespace CarBook.WebApp.Validators.AuthValidators
{
    public class LoginAppUserViewModelValidator : AbstractValidator<LoginAppUserViewModel>
    {
        public LoginAppUserViewModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is not valid. It must contain @ and .");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
