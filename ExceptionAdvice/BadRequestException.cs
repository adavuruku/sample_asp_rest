using System;
using Microsoft.AspNetCore.Http;

namespace BookStoreApi.ExceptionAdvice;

public class BadRequestException : Exception
{
    public HttpStatus httpStatus { get; }
    public object? Data { get; }
    public BadRequestException(string message) : base(message)
    {
        httpStatus = HttpStatus.BadRequest;
    }

    public BadRequestException(HttpStatus _httpStatus, string message) : base(message)
    {
        httpStatus = _httpStatus;
    }

    public BadRequestException(HttpStatus _httpStatus, string message, object data) : base(message)
    {
        httpStatus = _httpStatus;
        this.Data = data;
    }
}
