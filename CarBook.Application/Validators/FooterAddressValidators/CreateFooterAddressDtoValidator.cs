using CarBook.Application.Dtos.FooterAddressDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.FooterAddressValidators
{
    public class CreateFooterAddressDtoValidator : AbstractValidator<CreateFooterAddressDto>
    {
        public CreateFooterAddressDtoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.Address)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(100);
            RuleFor(x => x.Phone)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
