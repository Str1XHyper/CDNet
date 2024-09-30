using CodeByT.CDNet.Models.Enums;

namespace CodeByT.CDNet.Models.Exceptions;

public class HttpResponseException : Exception
{
    public HttpResponseException(int statusCode, object? value = null) =>
        (StatusCode, Value) = (statusCode, value);
    public HttpResponseException(ExceptionType statusCode, object? value = null) =>
        (StatusCode, Value) = ((int)statusCode, value);

    public int StatusCode { get; }

    public object? Value { get; }
}