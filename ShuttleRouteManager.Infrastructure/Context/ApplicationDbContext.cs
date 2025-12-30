using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Domain.Absractions;
using ShuttleRouteManager.Domain.Entities;
using System.Security.Claims;

namespace ShuttleRouteManager.Infrastructure.Context;

public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<RouteStop> RouteStops { get; set; }
    public DbSet<TripAppUser> TripAppUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.Ignore<IdentityUserClaim<Guid>>();
        modelBuilder.Ignore<IdentityRoleClaim<Guid>>();
        modelBuilder.Ignore<IdentityUserToken<Guid>>();
        modelBuilder.Ignore<IdentityUserLogin<Guid>>();
        modelBuilder.Ignore<IdentityUserRole<Guid>>();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("=== SaveChangesAsync STARTED ===");

        var allEntries = ChangeTracker.Entries().ToList();
        Console.WriteLine($"Total tracked entries: {allEntries.Count}");

        foreach (var e in allEntries)
        {
            Console.WriteLine($"  - Type: {e.Entity.GetType().Name}, State: {e.State}");
        }

        var entries = ChangeTracker.Entries<Entity>().ToList();
        Console.WriteLine($"Entity base class entries: {entries.Count}");

        var userIdClaim = _httpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        Guid userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;
        Console.WriteLine($"UserId from token: {userId}");

        foreach (var entry in entries)
        {
            Console.WriteLine($"Processing entity: {entry.Entity.GetType().Name}, State: {entry.State}");

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTimeOffset.Now;
                entry.Property(p => p.CreateUserId).CurrentValue = userId;
                Console.WriteLine($"  -> Set CreatedDate and CreateUserId");
            }
            else if (entry.State == EntityState.Modified)
            {
                if (entry.Property(p => p.IsDeleted).CurrentValue == true)
                {
                    entry.Entity.DeletedDate = DateTimeOffset.Now;
                    entry.Property(p => p.DeletedUserId).CurrentValue = userId;
                    Console.WriteLine($"  -> Soft delete");
                }
                else
                {
                    entry.Entity.LastUpdatedDate = DateTimeOffset.Now;
                    entry.Property(p => p.LastUpdateUserId).CurrentValue = userId;
                    Console.WriteLine($"  -> Updated");
                }
            }

            if (entry.State == EntityState.Deleted)
            {
                throw new InvalidOperationException("Physical deletion is not allowed. Use soft delete by setting IsDeleted to true.");
            }
        }

        Console.WriteLine("=== SaveChangesAsync FINISHED ===");
        return base.SaveChangesAsync(cancellationToken);
    }

    async Task<bool> IUnitOfWork.SaveChangesAsync()
    {
        return await SaveChangesAsync() > 0;
    }
}