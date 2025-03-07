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
            var validationResult =
                _validator.Validate((T)context.ActionArguments.Values.FirstOrDefault());

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
