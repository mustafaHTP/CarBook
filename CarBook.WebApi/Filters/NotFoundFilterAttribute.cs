using CarBook.Application.Helpers;
using CarBook.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarBook.WebApi.Filters
{
    public class NotFoundFilterAttribute<T> : ActionFilterAttribute where T : class
    {
        private readonly IRepository<T> _repository;

        public NotFoundFilterAttribute(IRepository<T> repository)
        {
            _repository = repository;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionArguments.TryGetValue("id", out object? routeId))
                throw new BadHttpRequestException("Id is required");

            var id = routeId as int?;
            if(!id.HasValue || id is null)
                throw new BadHttpRequestException("Id must be an integer");

            var entity = await _repository.GetByIdAsync(id.Value);
            if (entity is null)
                ExceptionHelper.ThrowIfNotFound<T>(id.Value);

            await next();
        }
    }
}
