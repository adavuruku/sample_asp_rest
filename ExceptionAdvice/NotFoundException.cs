using System;

namespace BookStoreApi.ExceptionAdvice;

public class NotFoundException : Exception
{
    public int httpStatus { get; }
    public object? Data { get; }
    public NotFoundException(string message) : base(message)
    {
        httpStatus = StatusCodes.Status404NotFound;
    }

    public NotFoundException(int _httpStatus, string message) : base(message)
    {
        httpStatus = _httpStatus;
    }

    public NotFoundException(int _httpStatus, string message, object data) : base(message)
    {
        httpStatus = _httpStatus;
        this.Data= data;
    }
}
