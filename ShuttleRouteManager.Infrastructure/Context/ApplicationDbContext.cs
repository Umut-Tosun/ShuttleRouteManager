using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Domain.Absractions;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Infrastructure.Context;

internal class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
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
        var entries = ChangeTracker.Entries<Entity>();
        HttpContextAccessor httpContextAccessor = new();

        // Kullanıcı ID'sini al (JWT token'dan)
        var userIdClaim = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "sub");
        Guid userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTimeOffset.Now;
                entry.Property(p => p.CreateUserId).CurrentValue = userId;
            }
            else if (entry.State == EntityState.Modified)
            {
                if (entry.Property(p => p.IsDeleted).CurrentValue == true)
                {
                    // Soft delete
                    entry.Entity.DeletedDate = DateTimeOffset.Now;
                    entry.Property(p => p.DeletedUserId).CurrentValue = userId;
                }
                else
                {
                    entry.Entity.LastUpdatedDate = DateTimeOffset.Now;
                    entry.Property(p => p.LastUpdateUserId).CurrentValue = userId;
                }
            }

            if (entry.State == EntityState.Deleted)
            {
                // Hard delete'e izin verme - soft delete kullan
                throw new InvalidOperationException("Physical deletion is not allowed. Use soft delete by setting IsDeleted to true.");
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    async Task<bool> IUnitOfWork.SaveChangesAsync()
    {
        return await SaveChangesAsync() > 0;
    }
}
