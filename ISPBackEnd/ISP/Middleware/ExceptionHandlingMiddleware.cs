using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Ecommerce.API.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    _logger.LogError(
                        "{ExceptionType} ,  {ExceptionMessage}",
                        ex.InnerException.GetType().ToString()
                        , ex.InnerException.Message
                        );
                }
                else
                { // for example error related to sql
                    _logger.LogError(
                        "{ExceptionType} ,  {ExceptionMessage}",
                        ex.GetType().ToString()
                        , ex.Message
                        );
                }
                httpContext.Response.StatusCode = 503;
              await httpContext.Response.WriteAsync("Error occured"); // this is my own exceptiom message to response
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
