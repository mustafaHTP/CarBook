using CarBook.Application.Dtos.TestimonialDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.TestimonialValidators
{
    public class UpdateTestimonialDtoValidator : AbstractValidator<UpdateTestimonialDto>
    {
        public UpdateTestimonialDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Title)
                .NotEmpty();
            RuleFor(x => x.Comment)
                .NotEmpty();
            RuleFor(x => x.ImageUrl)
                .NotEmpty();
        }
    }
}
