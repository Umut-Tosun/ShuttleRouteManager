using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.AppUsers.Result;

namespace ShuttleRouteManager.Application.Features.AppUsers.Queries;

public class LoginQuery : IRequest<BaseResult<LoginQueryResult>>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
