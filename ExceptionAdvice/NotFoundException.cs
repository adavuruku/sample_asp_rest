using System;

namespace BookStoreApi.ExceptionAdvice;

public class NotFoundException : Exception
{
    public HttpStatus httpStatus { get; }
    public object? Data { get; }
    public NotFoundException(string message) : base(message)
    {
        httpStatus = HttpStatus.NotFound;
    }

    public NotFoundException(HttpStatus _httpStatus, string message) : base(message)
    {
        httpStatus = _httpStatus;
    }

    public NotFoundException(HttpStatus _httpStatus, string message, object data) : base(message)
    {
        httpStatus = _httpStatus;
        this.Data= data;
    }
}
