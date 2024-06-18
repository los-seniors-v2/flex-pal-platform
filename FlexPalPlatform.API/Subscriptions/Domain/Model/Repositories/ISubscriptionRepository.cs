using FlexPalPlatform.API.Subscriptions.Domain.Model.Aggregates;
using FlexPalPlatform.API.Subscriptions.Domain.Model.ValueObjects;
using FlexPalPlatform.API.Shared.Domain.Repositories;

namespace FlexPalPlatform.API.Subscriptions.Domain.Model.Repositories;

public interface ISubscriptionRepository : IBaseRepository<Subscription>
{
    Task<Subscription?> FindSubscriptionByIdAsync(int id);
}