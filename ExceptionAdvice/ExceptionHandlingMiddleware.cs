using System;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.ExceptionAdvice;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    private static readonly Dictionary<Type, Func<Exception, HttpContext, ErrorResponse>> _exceptionHandlers = new()
    {
        [typeof(NotFoundException)] = (ex, context) =>
        {
            var notFound = (NotFoundException)ex;
            context.Response.StatusCode = notFound.httpStatus.Code;
            return CreateProblem(context, notFound.httpStatus,notFound.Data, ex.Message);
        },
        [typeof(BadRequestException)] = (ex, context) =>
        {
            var badRequest = (BadRequestException)ex;
            context.Response.StatusCode = badRequest.httpStatus.Code;
            return CreateProblem(context, badRequest.httpStatus, badRequest.Data, ex.Message);
        }
    };

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

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (_exceptionHandlers.TryGetValue(exception.GetType(), out var handler))
        {
            var problem = handler(exception, context);
            return context.Response.WriteAsJsonAsync(problem);
        }

        var fallbackStatus = HttpStatus.InternalServerError;
        context.Response.StatusCode = fallbackStatus.Code;
        var fallbackProblem = CreateProblem(context, fallbackStatus, null, exception.Message);
        return context.Response.WriteAsJsonAsync(fallbackProblem);
    }

    private static ErrorResponse CreateProblem(HttpContext context, HttpStatus status, Object? data, string detail)
    {
        ErrorResponse err = new ErrorResponse
        {
            Title = status.Message,
            Status = status.Code,
            Detail = detail,
            Instance = context.Request.Path,
            Data = data
        };
        return err;
    }
}