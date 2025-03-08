using CarBook.Application;
using CarBook.Application.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace CarBook.WebApi.Middlewares
{
    public class ErrorHandlingMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            httpContext.Response.StatusCode = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            var response = ApiResponse.Failure(ex.Message);
            var responseJson = JsonConvert.SerializeObject(response);

            await httpContext.Response.WriteAsync(responseJson);
        }
    }
}
