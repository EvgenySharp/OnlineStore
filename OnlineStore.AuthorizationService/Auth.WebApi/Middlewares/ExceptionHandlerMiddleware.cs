using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AuthApplicationException = Auth.BuisnessLayer.Abstractions.Сlasses.AuthApplicationException;

namespace Auth.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate requestDelegate)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (AuthApplicationException exception)
            {
                ProblemDetails problem = new()
                {
                    Status = (int)exception.StatusCodes,
                    Type = exception.GetType().Name,
                    Detail = exception.Detail
                };

                await ExceptionHandler(exception, problem, context);
            }
            catch (Exception exception)
            {
                ProblemDetails problem = new()
                {
                    Status = 500,
                    Type = exception.GetType().Name,
                    Detail = "The exception is not documented"
                };

                await ExceptionHandler(exception, problem, context);
            }
        }

        private async Task ExceptionHandler(Exception exception, ProblemDetails problem, HttpContext context)
        {
            var message = exception.Message;

            var exceptionRsult = JsonSerializer.Serialize(problem);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)problem.Status;

            _logger.LogError(exception, message);

            await context.Response.WriteAsync(exceptionRsult);

            return;
        }
    }
}