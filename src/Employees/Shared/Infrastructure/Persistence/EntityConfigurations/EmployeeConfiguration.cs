using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Employees.Domain;
using Rusell.Shared.Extensions;

namespace Rusell.Employees.Shared.Infrastructure.Persistence.EntityConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(v => v.Value, v => EmployeeId.From(v));

        builder.OwnsOne(x => x.FirstName)
            .Property(x => x.Value)
            .HasMaxLength(64)
            .HasColumnName(nameof(Employee.FirstName).ToDatabaseFormat());

        builder.OwnsOne(x => x.MiddleName)
            .Property(x => x.Value)
            .HasMaxLength(64)
            .HasColumnName(nameof(Employee.MiddleName).ToDatabaseFormat());

        builder.OwnsOne(x => x.FirstSurname)
            .Property(x => x.Value)
            .HasMaxLength(64)
            .HasColumnName(nameof(Employee.FirstSurname).ToDatabaseFormat());

        builder.OwnsOne(x => x.SecondSurname)
            .Property(x => x.Value)
            .HasMaxLength(64)
            .HasColumnName(nameof(Employee.SecondSurname).ToDatabaseFormat());

        builder.OwnsOne(x => x.Email)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Employee.Email).ToDatabaseFormat());

        builder.OwnsOne(x => x.PhoneNumber)
            .Property(x => x.Value)
            .HasMaxLength(10)
            .HasColumnName(nameof(Employee.PhoneNumber).ToDatabaseFormat());

        builder.Property(x => x.Type)
            .HasConversion(
                v => v.ToString(),
                v => (EmployeeType) Enum.Parse(typeof(EmployeeType), v))
            .HasMaxLength(64);

        builder.Property(x => x.CompanyId)
            .HasConversion(v => v.Value, v => CompanyId.From(v));

        builder.HasIndex(x => x.CompanyId);
    }
}
