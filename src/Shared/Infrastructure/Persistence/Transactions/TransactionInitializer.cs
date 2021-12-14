using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Rusell.Shared.Domain.Persistence.Transactions;

namespace Rusell.Shared.Infrastructure.Persistence.Transactions;

public class TransactionInitializer : ITransactionInitializer
{
  private readonly DbContext _context;

  public TransactionInitializer(DbContext context)
  {
    _context = context;
  }

  public async Task<IDbContextTransaction> Begin(DbContext dbContext) =>
    await _context.Database.BeginTransactionAsync();
}