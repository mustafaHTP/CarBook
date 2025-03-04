using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace CarBook.Application.Validators
{
    public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
    {
        public IActionResult CreateActionResult(ActionExecutingContext context, ValidationProblemDetails? validationProblemDetails)
        {
            var areaName = context.ActionDescriptor.RouteValues["area"];
            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            var actionName = context.ActionDescriptor.RouteValues["action"];
            var viewName = $"{controllerName}/{actionName}";

            return new ViewResult
            {
                ViewName = areaName is null ? viewName : $"{areaName}/{viewName}",
            };
        }
    }
}
