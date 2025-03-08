using CarBook.Application.Dtos.RentalPeriodDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.RentalPeriodValidator
{
    public class CreateRentalPeriodDtoValidator : AbstractValidator<CreateRentalPeriodDto>
    {
        public CreateRentalPeriodDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
