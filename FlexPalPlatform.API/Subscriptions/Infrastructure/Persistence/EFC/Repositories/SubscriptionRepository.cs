using FlexPalPlatform.API.Subscriptions.Domain.Model.Aggregates;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Repositories;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlexPalPlatform.API.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(AppDbContext context) : base(context)
    {
    }

    public Task<Subscription?> FindSubscriptionByIdAsync(int id)
    {
        return Context.Set<Subscription>().Where(s => s.Id == id).FirstOrDefaultAsync();
    }
}