using CarBook.Application.Dtos.ReservationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReservationValidators
{
    public class CreateReservationDtoValidator : AbstractValidator<CreateReservationDto>
    {
        public CreateReservationDtoValidator()
        {
            RuleFor(x => x.CarId).NotEmpty();
            RuleFor(x => x.CustomerFirstName).NotEmpty();
            RuleFor(x => x.CustomerLastName).NotEmpty();
            RuleFor(x => x.CustomerEmail).NotEmpty().EmailAddress();
            RuleFor(x => x.PickUpLocationId).NotEmpty();
            RuleFor(x => x.DropOffLocationId).NotEmpty();
        }
    }
}
