using CarBook.Application.Dtos.CarDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.CarValidators
{
    public class CreateCarDtoValidator : AbstractValidator<CreateCarDto>
    {
        public CreateCarDtoValidator()
        {
            RuleFor(x => x.ModelId)
                .NotEmpty();
            RuleFor(x => x.Km)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.TransmissionType)
                .NotEmpty();
            RuleFor(x => x.FuelType)
                .NotEmpty();
            RuleFor(x => x.SeatCount)
                .NotEmpty();
            RuleFor(x => x.Luggage)
                .NotEmpty();
            RuleFor(x => x.CoverImageUrl)
                .NotEmpty();
            RuleFor(x => x.BigImageUrl)
                .NotEmpty();
        }
    }
}
