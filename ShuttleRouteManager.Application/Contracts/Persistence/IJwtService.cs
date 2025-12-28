using ShuttleRouteManager.Application.Features.AppUsers.Result;

namespace ShuttleRouteManager.Application.Contracts.Persistence;

public interface IJwtService
{
    Task<LoginQueryResult> GenerateTokenAsync(GetAppUsersQueryResult user);
}