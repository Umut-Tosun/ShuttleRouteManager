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
    #region Audit Log
    public DateTimeOffset CreatedDate { get; set; } = DateTime.Now;
    public Guid CreateUserId { get; set; } = default!;
    public string CreateUserName => GetCreateUserName();
    public DateTimeOffset LastUpdatedDate { get; set; }
    public Guid? LastUpdateUserId { get; set; }
    public string? LastUpdateUserName => GetLastUpdateUserName();
    public bool IsDeleted { get; set; } = false;
    public Guid? DeletedUserId { get; set; }
    public string? DeletedUserName => GetDeletedUserName();
    public DateTimeOffset? DeletedDate { get; set; }
    #endregion
    private string GetCreateUserName()
    {

        HttpContextAccessor httpContextAccessor = new();
        var userManager = httpContextAccessor.HttpContext.RequestServices.GetRequiredService<UserManager<AppUser>>();
        AppUser appUser = userManager.Users.First(p => p.Id == CreateUserId);
        return appUser.FirstName + " " + appUser.LastName;
    }
    private string? GetLastUpdateUserName()
    {
        if (LastUpdateUserId is null)
        {
            return string.Empty;
        }
        HttpContextAccessor httpContextAccessor = new();
        var userManager = httpContextAccessor.HttpContext.RequestServices.GetRequiredService<UserManager<AppUser>>();
        AppUser appUser = userManager.Users.First(p => p.Id == LastUpdateUserId);
        return appUser.FirstName + " " + appUser.LastName;

    }
    private string? GetDeletedUserName()
    {
        if (DeletedUserId is null)
        {
            return string.Empty;
        }
        HttpContextAccessor httpContextAccessor = new();
        var userManager = httpContextAccessor.HttpContext.RequestServices.GetRequiredService<UserManager<AppUser>>();
        AppUser appUser = userManager.Users.First(p => p.Id == DeletedUserId);
        return appUser.FirstName + " " + appUser.LastName;
    }
}
