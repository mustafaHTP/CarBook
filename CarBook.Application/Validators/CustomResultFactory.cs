using CarBook.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace CarBook.Application.Validators
{
    public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
    {
        public IActionResult CreateActionResult(ActionExecutingContext context, ValidationProblemDetails? validationProblemDetails)
        {
            if(validationProblemDetails == null || validationProblemDetails.Errors.Count == 0)
            {
                throw new Exception("ValidationProblemDetails is null or empty");
            }

            throw new ArgumentValidationException(validationProblemDetails.Errors);
        }
    }
}
