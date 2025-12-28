using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace ShuttleRouteManager.Application.Base;

public class BaseResult<T>
{
    public T Data { get; set; }
    [JsonIgnore]
    public bool IsSuccess => Messages == null || !Messages.Any();
    [JsonIgnore]
    public bool IsFailure => !IsSuccess;
    public IEnumerable<Error>? Messages { get; set; }



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
        return new BaseResult<T> { Messages = [new Error { Message = "an Unexpected Error Ocurred" }] };
    }

    public static BaseResult<T> Failure(string message)
    {
        return new BaseResult<T> { Messages = [new Error { Message = message }] };
    }

    public static BaseResult<T> NotFound(string message)
    {
        return new BaseResult<T> { Messages = [new Error { Message = message }] };
    }


}
