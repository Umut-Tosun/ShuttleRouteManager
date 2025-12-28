using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Domain.Absractions;

public abstract class Entity
{
    // Lazy loading için cache field'ları
    private string? _createUserName;
    private string? _lastUpdateUserName;
    private string? _deletedUserName;

    public Entity()
    {
        Id = Guid.CreateVersion7();
    }

    public Guid Id { get; set; }

    #region Audit Log
    public DateTimeOffset CreatedDate { get; set; } = DateTime.Now;
    public Guid CreateUserId { get; set; } = default!;

    
    public string CreateUserName
    {
        get
        {
            if (_createUserName == null)
            {
                _createUserName = GetCreateUserName();
            }
            return _createUserName;
        }
    }

    public DateTimeOffset LastUpdatedDate { get; set; }
    public Guid? LastUpdateUserId { get; set; }

   
    public string? LastUpdateUserName
    {
        get
        {
            if (LastUpdateUserId == null)
                return string.Empty;

            if (_lastUpdateUserName == null)
            {
                _lastUpdateUserName = GetLastUpdateUserName();
            }
            return _lastUpdateUserName;
        }
    }

    public bool IsDeleted { get; set; } = false;
    public Guid? DeletedUserId { get; set; }

    
    public string? DeletedUserName
    {
        get
        {
            if (DeletedUserId == null)
                return string.Empty;

            if (_deletedUserName == null)
            {
                _deletedUserName = GetDeletedUserName();
            }
            return _deletedUserName;
        }
    }

    public DateTimeOffset? DeletedDate { get; set; }
    #endregion

    private string GetCreateUserName()
    {
        try
        {
            HttpContextAccessor httpContextAccessor = new();
            var httpContext = httpContextAccessor.HttpContext;

            if (httpContext == null)
                return "System";

            var userManager = httpContext.RequestServices.GetRequiredService<UserManager<AppUser>>();
            var appUser = userManager.Users.FirstOrDefault(p => p.Id == CreateUserId);

            return appUser != null ? $"{appUser.FirstName} {appUser.LastName}" : "Unknown";
        }
        catch
        {
            return "System";
        }
    }

    private string? GetLastUpdateUserName()
    {
        if (LastUpdateUserId is null)
            return string.Empty;

        try
        {
            HttpContextAccessor httpContextAccessor = new();
            var httpContext = httpContextAccessor.HttpContext;

            if (httpContext == null)
                return "System";

            var userManager = httpContext.RequestServices.GetRequiredService<UserManager<AppUser>>();
            var appUser = userManager.Users.FirstOrDefault(p => p.Id == LastUpdateUserId);

            return appUser != null ? $"{appUser.FirstName} {appUser.LastName}" : "Unknown";
        }
        catch
        {
            return "System";
        }
    }

    private string? GetDeletedUserName()
    {
        if (DeletedUserId is null)
            return string.Empty;

        try
        {
            HttpContextAccessor httpContextAccessor = new();
            var httpContext = httpContextAccessor.HttpContext;

            if (httpContext == null)
                return "System";

            var userManager = httpContext.RequestServices.GetRequiredService<UserManager<AppUser>>();
            var appUser = userManager.Users.FirstOrDefault(p => p.Id == DeletedUserId);

            return appUser != null ? $"{appUser.FirstName} {appUser.LastName}" : "Unknown";
        }
        catch
        {
            return "System";
        }
    }
}