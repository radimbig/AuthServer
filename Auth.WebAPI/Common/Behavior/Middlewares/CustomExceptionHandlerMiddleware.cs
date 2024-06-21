using Auth.ModelsCore.Exceptions;
using System.Text.Json;

namespace Auth.WebAPI.Common.Behavior.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = StatusCodes.Status500InternalServerError;
            string responseBody = string.Empty;
            context.Response.ContentType = "application/json";


            if (exception is IAuthException authException)
            {
                code = authException.ErrorCode;
                responseBody = JsonSerializer.Serialize(authException);

            }

            if (responseBody == string.Empty)
            {
                responseBody = JsonSerializer.Serialize(new { error = exception.Message });
            }

            context.Response.StatusCode = code;
            return context.Response.WriteAsync(responseBody);

        }
    }
}
