using CarBook.WebApp.Models.AuthModels;
using FluentValidation;

namespace CarBook.WebApp.Validators.AuthValidators
{
    public class RegisterAppUserViewModelValidator : AbstractValidator<RegisterAppUserViewModel>
    {
        public RegisterAppUserViewModelValidator()
        {
            RuleFor(x => x.FirstName)
               .NotEmpty()
               .WithMessage("First name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is not valid");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .Equal(x => x.ConfirmPassword)
                .WithMessage("Password and confirm password do not match");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Confirm password is required")
                .Equal(x => x.Password)
                .WithMessage("Password and confirm password do not match");
        }
    }
}
