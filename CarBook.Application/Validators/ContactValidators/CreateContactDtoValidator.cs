using CarBook.Application.Dtos.ContactDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ContactValidators
{
    public class CreateContactDtoValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Message)
                .NotEmpty()
                .MaximumLength(500);
            RuleFor(x => x.Subject)
                .NotEmpty()
                .MaximumLength(75);
            RuleFor(x => x.SendDate)
                .NotEmpty();
        }
    }
}
