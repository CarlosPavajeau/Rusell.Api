using Microsoft.EntityFrameworkCore;
using Rusell.Shared.Domain.Persistence;

namespace Rusell.Shared.Infrastructure.Persistence;

public class UnitWork : IUnitWork
{
  private readonly DbContext _context;

  public UnitWork(DbContext context)
  {
    _context = context;
  }

  public async Task SaveChanges()
  {
    await _context.SaveChangesAsync();
  }
}