using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Parcels.Employees.Domain;
using Rusell.Shared.Extensions;

namespace Rusell.Parcels.Shared.Infrastructure.Persistence.EntityFramework.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(v => v.Value, v => EmployeeId.From(v));

        builder.OwnsOne(x => x.FullName)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Employee.FullName).ToDatabaseFormat());
    }
}
