using FlexPalPlatform.API.Subscriptions.Domain.Model.Aggregates;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Queries;

namespace FlexPalPlatform.API.Subscriptions.Domain.Model.Services;

public interface ISubscriptionQueryService
{
    Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query);
    Task<Subscription?> Handle(GetSubscriptionByIdQuery query);
}