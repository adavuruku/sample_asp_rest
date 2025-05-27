using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.ExceptionAdvice;


public class ErrorResponse : ProblemDetails
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    [JsonPropertyOrder(1)]
    public object? Data { get; set; }
}
