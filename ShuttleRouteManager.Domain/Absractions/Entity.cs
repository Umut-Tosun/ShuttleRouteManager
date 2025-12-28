using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Domain.Absractions;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.CreateVersion7();
    }

    public Guid Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; } = DateTime.Now;
    public Guid CreateUserId { get; set; } = default!;
    public DateTimeOffset LastUpdatedDate { get; set; }
    public Guid? LastUpdateUserId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public Guid? DeletedUserId { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }

    
}