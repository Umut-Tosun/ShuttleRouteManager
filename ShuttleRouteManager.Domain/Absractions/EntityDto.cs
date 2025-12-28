namespace ShuttleRouteManager.Domain.Absractions;

public abstract class EntityDto
{

    public Guid Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public Guid CreateUserId { get; set; }
    public string CreateUserName { get; set; } = default!;
    public DateTimeOffset LastUpdatedDate { get; set; }
    public Guid? LastUpdateUserId { get; set; }
    public string? LastUpdateUserName { get; set; }
    public bool IsDeleted { get; set; } = false;
    public Guid? DeletedUserId { get; set; }
    public string? DeletedUserName { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
}
