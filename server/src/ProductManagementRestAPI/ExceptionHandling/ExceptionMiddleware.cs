using System.Net;
using System.Resources;
using FluentValidation;
using Shared.Core;
using Shared.Core.Exceptions;

namespace ProductManagementRestAPI.ExceptionHandling
{
    public class ExceptionMiddleware
    {
        public static ResourceManager ResourceManager;
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            if (exception?.InnerException is BusinessException businessException)
            {
                return GenerateResponse(businessException.Code, GetExceptionMessage(businessException), context);
            }
            if (exception is ValidationException validateException)
            {
                return GenerateResponse(validateException.Errors.FirstOrDefault().ErrorCode, GetValidationExceptionMessage(validateException), context);
            }
            _logger.Error(exception);

            return GenerateResponse(HttpStatusCode.InternalServerError.ToString(), "Internal Server Error", context);
        }

        private Task GenerateResponse(string code, string message, HttpContext context)
        {
            return context.Response.WriteAsync(new ErrorDetails()
            {
                Code = code,
                ErrorMessage = message
            }.ToString());
        }

        private string GetExceptionMessage(BusinessException businessException)
        {
            if (!string.IsNullOrEmpty(businessException.ExceptionMessage)) 
                return businessException.ExceptionMessage;
            return GetErrorFromResourceFile(businessException.Code);
        }
        private string GetValidationExceptionMessage(ValidationException validationException)
        {
            var error = validationException.Errors.FirstOrDefault();
            if (!string.IsNullOrEmpty(error?.ErrorMessage))
                return error.ErrorMessage;
            return GetErrorFromResourceFile(error?.ErrorCode);
        }
        private string GetErrorFromResourceFile(string code) => ResourceManager.GetString(code);
    }
}
