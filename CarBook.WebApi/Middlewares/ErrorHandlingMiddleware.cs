using CarBook.Application;
using CarBook.Application.Exceptions;
using CarBook.Application.Responses;
using CarBook.WebApi.Responses;
using Newtonsoft.Json;
using System.Net;

namespace CarBook.WebApi.Middlewares
{
    public class ErrorHandlingMiddleware(RequestDelegate next)
    {
        private const string UnExpectedError = "An unexpected error occurred. Please try again later.";
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
            int statusCode = (int) HttpStatusCode.InternalServerError;
            string title = "Internal Server Error";
            List<string> messages = new();

            switch (ex)
            {
                case ArgumentValidationException argumentValidationException:
                    statusCode = (int)argumentValidationException.StatusCode;
                    title = argumentValidationException.Title;

                    messages.AddRange(argumentValidationException.MessageProps);

                    break;

                case BaseCustomException baseCustomException:
                    statusCode = (int)baseCustomException.StatusCode;
                    title = baseCustomException.Title;

                    var messageFormat = baseCustomException.MessageFormat;
                    foreach (var messageProp in baseCustomException.MessageProps)
                    {
                        messageFormat = messageFormat.Replace(messageProp.Key, messageProp.Value);
                    }

                    messages.Add(messageFormat);
                    break;
                default:
                    messages.Add(UnExpectedError);
                    break;
            }

            var problemDetails = new ProblemDetails
            {
                Title = title,
                Status = statusCode,
                Detail = string.Join(Environment.NewLine, [.. messages])
            };

            //Prepare response
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            var genericApiResult = GenericApiResponse<EmptyApiResult>.Failure(problemDetails);
            var json = JsonConvert.SerializeObject(genericApiResult);
            await httpContext.Response.WriteAsync(json);
        }
    }
}
