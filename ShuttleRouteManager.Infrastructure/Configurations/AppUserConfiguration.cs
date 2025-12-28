using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Infrastructure.Configurations;

internal sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.HomeCity)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.HomeDistrict)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.HomeAddress)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(u => u.HomeLatitude)
            .IsRequired()
            .HasPrecision(18, 10);

        builder.Property(u => u.HomeLongitude)
            .IsRequired()
            .HasPrecision(18, 10);

      
        builder.HasOne(u => u.DefaultRouteStop)
            .WithMany(rs => rs.DefaultAppUsers)
            .HasForeignKey(u => u.DefaultRouteStopId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(u => u.TripAppUsers)
            .WithOne(t => t.AppUser)
            .HasForeignKey(t => t.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        
        builder.HasQueryFilter(u => !u.IsDeleted);
    }
}