using FlexPalPlatform.API.Subscriptions.Domain.Model.Aggregates;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Queries;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Repositories;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Services;


namespace FlexPalPlatform.API.Subscriptions.Application.Internal.QueryServices;

public class SubscriptionQueryService(ISubscriptionRepository subscriptionRepository) : ISubscriptionQueryService
{

    public async Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query)
    {
        return await subscriptionRepository.ListAsync();
    }

    public async Task<Subscription?> Handle(GetSubscriptionByIdQuery query)
    {
        return await subscriptionRepository.FindSubscriptionByIdAsync(query.SubscriptionId);
    }
}