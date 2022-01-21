using Microsoft.EntityFrameworkCore;
using Rusell.BankDrafts.Domain;
using Rusell.Shared.Infrastructure.Repository;

namespace Rusell.BankDrafts.Infrastructure.Persistence;

public class EntityFrameworkBankDraftsRepository : Repository<BankDraft, BankDraftId>, IBankDraftsRepository
{
    public EntityFrameworkBankDraftsRepository(DbContext context) : base(context)
    {
    }

    public override async Task<BankDraft?> Find(BankDraftId key, bool noTracking)
    {
        var query = noTracking ? Context.Set<BankDraft>().AsNoTracking() : Context.Set<BankDraft>().AsTracking();

        return await query
            .Include(x => x.Dispatcher)
            .Include(x => x.Sender)
            .Include(x => x.Receiver)
            .Include(x => x.Company)
            .FirstOrDefaultAsync(x => x.Id == key);
    }
}
