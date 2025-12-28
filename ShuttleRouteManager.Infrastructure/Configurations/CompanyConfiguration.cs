using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Infrastructure.Configurations;

internal sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Address)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(c => c.ResponsiblePerson)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.ResponsiblePersonPhoneNumber)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(c => c.TaxOffice)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.TaxNumber)
            .IsRequired()
            .HasMaxLength(20);

       
        builder.HasMany(c => c.Drivers)
            .WithOne(d => d.Company)
            .HasForeignKey(d => d.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Buses)
            .WithOne(b => b.Company)
            .HasForeignKey(b => b.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

       
        builder.HasQueryFilter(c => !c.IsDeleted);
    }
}
