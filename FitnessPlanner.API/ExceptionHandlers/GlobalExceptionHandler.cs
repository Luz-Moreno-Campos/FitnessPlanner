using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlanner.API.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails();

            if (exception is KeyNotFoundException)
            {
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Title = "Resource not found";
                problemDetails.Detail = exception.Message;
            }
            else if (exception is InvalidOperationException)
            {
                problemDetails.Status = StatusCodes.Status409Conflict;
                problemDetails.Title = "Conflict";
                problemDetails.Detail = exception.Message;
            }
            else
            {
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                problemDetails.Title = "Internal Server Error";
                problemDetails.Detail = "An unexpected error occurred.";
            }

            httpContext.Response.StatusCode =
                problemDetails.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}