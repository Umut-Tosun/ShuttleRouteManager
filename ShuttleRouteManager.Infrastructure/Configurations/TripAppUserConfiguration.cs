using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Infrastructure.Configurations;

internal sealed class TripAppUserConfiguration : IEntityTypeConfiguration<TripAppUser>
{
    public void Configure(EntityTypeBuilder<TripAppUser> builder)
    {
        builder.HasKey(t => t.Id);

      
        builder.HasOne(t => t.AppUser)
            .WithMany(u => u.TripAppUsers)
            .HasForeignKey(t => t.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Route)
            .WithMany(r => r.TripAppUsers)
            .HasForeignKey(t => t.RouteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.RouteStop)
            .WithMany(rs => rs.TripAppUsers)
            .HasForeignKey(t => t.RouteStopId)
            .OnDelete(DeleteBehavior.Restrict);

      
        builder.Property(t => t.TripType)
            .HasConversion<string>();

      
        builder.HasIndex(t => new { t.AppUserId, t.RouteId, t.TripType });

      
        builder.HasQueryFilter(t => !t.IsDeleted);
    }
}
