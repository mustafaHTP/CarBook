using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.WebApp.Filters
{
    public class ValidationFilterAttribute<T> : ActionFilterAttribute
    {
        private readonly IValidator<T> _validator;

        public ValidationFilterAttribute(IValidator<T> validator)
        {
            _validator = validator;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var argumentValue = context.ActionArguments.Values.FirstOrDefault();

            if (argumentValue == null)
            {
                // Handle the case where the argument is null.
                // You can add a model state error or set a result, depending on your needs.
                context.ModelState.AddModelError("Argument", "The required argument is missing.");

                string? actionName = context.ActionDescriptor.RouteValues["action"];
                context.Result = new ViewResult
                {
                    ViewName = actionName,
                };

                return; // Return early to avoid attempting validation on a null object.
            }

            var validationResult = _validator.Validate((T)argumentValue);

            if (!validationResult.IsValid)
            {
                context.ModelState.Clear();

                foreach (var item in validationResult.Errors)
                {
                    context.ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                string? actionName = context.ActionDescriptor.RouteValues["action"];
                context.Result = new ViewResult
                {
                    ViewName = actionName,
                };
            }

            base.OnActionExecuting(context);
        }
    }
}
