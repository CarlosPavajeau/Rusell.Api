using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Rusell.Shared.Domain.Persistence.Transactions;

public interface ITransactionInitializer
{
    Task<IDbContextTransaction> Begin(DbContext dbContext);
}