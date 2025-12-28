using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.API
{
    public sealed class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            BaseResult<string> errorResult;

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 500;

            if (exception.GetType() == typeof(ValidationException))
            {
                httpContext.Response.StatusCode = 403;

                errorResult = BaseResult<string>.Failure(403, ((ValidationException)exception).Errors.Select(s => s.PropertyName).ToList());

                await httpContext.Response.WriteAsJsonAsync(errorResult);

                return true;
            }

            errorResult = BaseResult<string>.Failure(exception.Message);

            await httpContext.Response.WriteAsJsonAsync(errorResult);

            return true;
        }
    }

}
