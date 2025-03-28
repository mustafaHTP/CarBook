﻿using CarBook.Application.Dtos.BannerDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.BannerValidators
{
    public class CreateBannerDtoValidator : AbstractValidator<CreateBannerDto>
    {
        public CreateBannerDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
            RuleFor(x => x.VideoUrl)
                .NotEmpty();
            RuleFor(x => x.VideoDescription)
                .NotEmpty();
        }
    }
}
