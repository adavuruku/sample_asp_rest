using System;
using System.Collections;
using Microsoft.AspNetCore.Http;

namespace BookStoreApi.ExceptionAdvice;

public class EClinicException : Exception
{
    public int httpStatus { get; }
    public object? Data { get; }
    public string? Code { get; }
    public string? Message { get; }
    public object[]? MessageParams { get; }

    public EClinicException(int _httpStatus, string message) : this(_httpStatus, message, null, null, null)
    { }

    public EClinicException(int _httpStatus, string message, object[]? messageParams) : this(_httpStatus, message, messageParams, null, null)
    { }

    public EClinicException(int _httpStatus, string message, object[]? messageParams, object data) : this(_httpStatus, message, messageParams, data, null)
    { }
    
    // public EClinicException(int _httpStatus, string message, string code) : this(_httpStatus, message, null, null, code) { }

    // public EClinicException(int _httpStatus, string message, object data) : this(_httpStatus, message, null, data, null) { }
    
    public EClinicException(int _httpStatus, string message, object[]? messageParams, object data, string code) : base(message)
    {
        this.httpStatus = _httpStatus;
        this.Data = data;
        this.Code = code;
        this.MessageParams = messageParams;
        this.Message = message;
    }
}
