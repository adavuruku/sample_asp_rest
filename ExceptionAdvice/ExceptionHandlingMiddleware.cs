using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace BookStoreApi.ExceptionAdvice;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IStringLocalizer<ExceptionHandlingMiddleware> _localizer;

    private readonly Dictionary<Type, Func<Exception, HttpContext, ErrorResponse>> _exceptionHandlers;
    

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IStringLocalizer<ExceptionHandlingMiddleware> localizer)
    {
        _next = next;
        _logger = logger;
        _localizer = localizer;

        _exceptionHandlers = new Dictionary<Type, Func<Exception, HttpContext, ErrorResponse>>
        {
            [typeof(NotFoundException)] = (ex, context) =>
        {
            var notFound = (NotFoundException)ex;
            context.Response.StatusCode = notFound.httpStatus;
            return CreateProblem(context, notFound.httpStatus,  notFound.Message, null, notFound.Data,notFound.httpStatus.ToString());
        },
        [typeof(BadRequestException)] = (ex, context) =>
        {
            var badRequest = (BadRequestException)ex;
            context.Response.StatusCode = badRequest.httpStatus;
            return CreateProblem(context, badRequest.httpStatus,  badRequest.Message, null, badRequest.Data, badRequest.httpStatus.ToString());
        },

            [typeof(EClinicException)] = (ex, context) =>
            {
                var eclinicException = (EClinicException)ex;
                context.Response.StatusCode = eclinicException.httpStatus;
                var message = eclinicException.Message;
                return CreateProblem(context, eclinicException.httpStatus, message, eclinicException.MessageParams, eclinicException.Data, eclinicException.Code);
            }
        };
    }

    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // call next middleware
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (_exceptionHandlers.TryGetValue(exception.GetType(), out var handler))
        {
            var problem = handler(exception, context);
            return context.Response.WriteAsJsonAsync(problem);
        }

        var fallbackStatus = StatusCodes.Status500InternalServerError;
        context.Response.StatusCode = fallbackStatus;
        var fallbackProblem = CreateProblem(context, fallbackStatus, exception.Message,Array.Empty<object>(), null, fallbackStatus.ToString());
        return context.Response.WriteAsJsonAsync(fallbackProblem);
    }

    private ErrorResponse CreateProblem(HttpContext context, int status, string message, object[]? messagePayload, object? data, string code)
    {
        var detail = message;
        if (message != null && messagePayload != null && messagePayload.Length > 0)
        {
            detail = _localizer.GetString(message, messagePayload);
        }

        return new ErrorResponse
        {
            Status = status,
            Detail = detail,
            Instance = context.Request.Path,
            Data = data,
            Code = code
        };
    }

}