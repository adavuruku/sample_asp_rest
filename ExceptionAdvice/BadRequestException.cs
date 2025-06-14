using System;
using Microsoft.AspNetCore.Http;

namespace BookStoreApi.ExceptionAdvice;

public class BadRequestException : Exception
{
    public int httpStatus { get; }
    public object? Data { get; }
    public BadRequestException(string message) : base(message)
    {
        httpStatus = StatusCodes.Status400BadRequest;
    }

    public BadRequestException(int _httpStatus, string message) : base(message)
    {
        httpStatus = _httpStatus;
    }

    public BadRequestException(int _httpStatus, string message, object data) : base(message)
    {
        httpStatus = _httpStatus;
        this.Data = data;
    }
}
