using System;

namespace BookStoreApi.ExceptionAdvice;

public class HttpStatus
{
    public static readonly HttpStatus OK = new(StatusCodes.Status200OK, "OK");
    public static readonly HttpStatus BadRequest = new(StatusCodes.Status400BadRequest, "Bad Request");
    public static readonly HttpStatus NotFound = new(StatusCodes.Status404NotFound, "Not Found");
    public static readonly HttpStatus InternalServerError = new(500, "Internal Server Error");

    public int Code { get; }
    public string Message { get; }

    private HttpStatus(int code, string message)
    {
        Code = code;
        Message = message;
    }

    public override string ToString() => $"{Code} - {Message}";
}
