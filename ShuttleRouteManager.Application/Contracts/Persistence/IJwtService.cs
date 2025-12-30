using ShuttleRouteManager.Application.Features.AppUsers.Result;

namespace ShuttleRouteManager.Application.Contracts.Persistence;

public interface IJwtService
{
    Task<LoginQueryResult> GenerateTokenAsync(GetAppUsersQueryResult user);
}
public interface ILogService
{
    void LogCreate(string entityType, string entityId, object newValue);
    void LogUpdate(string entityType, string entityId, object oldValue, object newValue);
    void LogDelete(string entityType, string entityId, object oldValue);
    Task<List<LogEntryDto>> GetLogsAsync(LogFilterDto filter);
    Task<int> GetTotalCountAsync(LogFilterDto filter);
}
public class LogEntryDto
{
    public int Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Level { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string? UserId { get; set; }
    public string? UserEmail { get; set; }
    public string? ActionType { get; set; }
    public string? EntityType { get; set; }
    public string? EntityId { get; set; }
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
    public string? IpAddress { get; set; }
}
public class LogFilterDto
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? ActionType { get; set; }
    public string? EntityType { get; set; }
    public string? UserId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}