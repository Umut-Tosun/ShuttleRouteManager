using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Infrastructure.Configurations;

internal sealed class RouteStopConfiguration : IEntityTypeConfiguration<RouteStop>
{
    public void Configure(EntityTypeBuilder<RouteStop> builder)
    {
        builder.HasKey(rs => rs.Id);

        builder.Property(rs => rs.City)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(rs => rs.District)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(rs => rs.Address)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(rs => rs.Latitude)
            .IsRequired()
            .HasPrecision(18, 10);

        builder.Property(rs => rs.Longitude)
            .IsRequired()
            .HasPrecision(18, 10);

       
        builder.HasOne(rs => rs.Route)
            .WithMany(r => r.RouteStops)
            .HasForeignKey(rs => rs.RouteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(rs => rs.DefaultAppUsers)
            .WithOne(u => u.DefaultRouteStop)
            .HasForeignKey(u => u.DefaultRouteStopId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(rs => rs.TripAppUsers)
            .WithOne(t => t.RouteStop)
            .HasForeignKey(t => t.RouteStopId)
            .OnDelete(DeleteBehavior.Restrict);

       
        builder.HasIndex(rs => new { rs.RouteId, rs.SequenceNumber });

        
        builder.HasQueryFilter(rs => !rs.IsDeleted);
    }
}