using CarBook.Application.Dtos.BlogCommentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.BlogCommentValidators
{
    public class UpdateBlogCommentDtoValidator : AbstractValidator<UpdateBlogCommentDto>
    {
        public UpdateBlogCommentDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.CreatedDate)
                .NotEmpty();
            RuleFor(x => x.Content)
                .NotEmpty();
            RuleFor(x => x.BlogId)
                .NotEmpty();
        }
    }
}
