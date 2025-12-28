using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Infrastructure.Configurations;

internal sealed class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(r => r.StartPoint)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(r => r.EndPoint)
            .IsRequired()
            .HasMaxLength(200);

       
        builder.HasOne(r => r.Bus)
            .WithMany(b => b.Routes)
            .HasForeignKey(r => r.BusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Driver)
            .WithMany(d => d.Routes)
            .HasForeignKey(r => r.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(r => r.RouteStops)
            .WithOne(rs => rs.Route)
            .HasForeignKey(rs => rs.RouteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.TripAppUsers)
            .WithOne(t => t.Route)
            .HasForeignKey(t => t.RouteId)
            .OnDelete(DeleteBehavior.Restrict);

    
        builder.HasQueryFilter(r => !r.IsDeleted);
    }
}