using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace ShuttleRouteManager.Application.Base;

public class BaseResult<T>
{
    public T Data { get; set; } = default!;
    public bool IsSuccess => Messages == null || !Messages.Any();
    public bool IsFailure => !IsSuccess;
    public IEnumerable<Error>? Messages { get; set; }
    public int? StatusCode { get; set; }

    public static BaseResult<T> Success(T data)
    {
        return new BaseResult<T> { Data = data };
    }

    public static BaseResult<T> Failure(IEnumerable<IdentityError> errors)
    {
        var errorList = errors.Select(e => new Error { PropertyName = e.Code, Message = e.Description });
        return new BaseResult<T> { Messages = errorList };
    }

    public static BaseResult<T> Failure(IEnumerable<Error> errors)
    {
        return new BaseResult<T> { Messages = errors };
    }

    public static BaseResult<T> Failure()
    {
        return new BaseResult<T> { Messages = [new Error { Message = "Beklenmeyen bir hata oluştu" }] };
    }

    public static BaseResult<T> Failure(string message)
    {
        return new BaseResult<T> { Messages = [new Error { Message = message }] };
    }

    public static BaseResult<T> NotFound(string message)
    {
        return new BaseResult<T> { Messages = [new Error { Message = message }] };
    }

   
    public static BaseResult<T> Failure(int statusCode, List<string> errorMessages)
    {
        var errors = errorMessages.Select(msg => new Error { Message = msg });
        return new BaseResult<T>
        {
            Messages = errors,
            StatusCode = statusCode
        };
    }

    public static BaseResult<T> Failure(int statusCode, string message)
    {
        return new BaseResult<T>
        {
            Messages = [new Error { Message = message }],
            StatusCode = statusCode
        };
    }

    public static BaseResult<T> Failure(int statusCode, IEnumerable<Error> errors)
    {
        return new BaseResult<T>
        {
            Messages = errors,
            StatusCode = statusCode
        };
    }
}