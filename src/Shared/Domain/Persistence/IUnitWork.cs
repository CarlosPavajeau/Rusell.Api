namespace Rusell.Shared.Domain.Persistence;

public interface IUnitWork
{
    Task SaveChanges();
}