using CarBook.Application.Dtos.LocationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.LocationValidators
{
    public class UpdateLocationDtoValidator : AbstractValidator<UpdateLocationDto>
    {
        public UpdateLocationDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
