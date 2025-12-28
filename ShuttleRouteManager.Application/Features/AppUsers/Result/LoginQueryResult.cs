namespace ShuttleRouteManager.Application.Features.AppUsers.Result;

public class LoginQueryResult
{
    public string Token { get; set; } = default!;
    public DateTime ExpirationTime { get; set; }
    public GetAppUsersQueryResult User { get; set; } = default!;
}