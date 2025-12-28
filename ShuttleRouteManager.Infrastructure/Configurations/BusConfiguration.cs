using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Infrastructure.Configurations;

internal sealed class BusConfiguration : IEntityTypeConfiguration<Bus>
{
    public void Configure(EntityTypeBuilder<Bus> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.PlateNo)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(b => b.Brand)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.Model)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.Km)
            .HasPrecision(18, 2);

       
        builder.HasIndex(b => b.PlateNo).IsUnique();

       
        builder.HasOne(b => b.Company)
            .WithMany(c => c.Buses)
            .HasForeignKey(b => b.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b => b.Routes)
            .WithOne(r => r.Bus)
            .HasForeignKey(r => r.BusId)
            .OnDelete(DeleteBehavior.Restrict);

       
        builder.HasQueryFilter(b => !b.IsDeleted);
    }
}
