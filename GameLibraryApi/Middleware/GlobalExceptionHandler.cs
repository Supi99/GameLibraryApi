using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GameLibraryApi.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            //log exception on server side
            _logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);

            //response for clients
            var problemDetail = new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An expected error has occurred",
                Detail = "Please try again or contact support team"
            };

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            //write json

            await httpContext.Response.WriteAsJsonAsync(problemDetail, cancellationToken);

            return true; //true because the problem is parsed by this method
        }
    }
}