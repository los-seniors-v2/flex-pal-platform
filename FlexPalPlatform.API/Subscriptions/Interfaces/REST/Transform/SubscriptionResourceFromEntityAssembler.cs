using FlexPalPlatform.API.Subscriptions.Domain.Model.Aggregates;
using FlexPalPlatform.API.Subscriptions.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Subscriptions.Interfaces.REST.Transform;

public static class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(Subscription entity)
    {
        bool isActive = entity.SubscriptionStatus.ToLower() == "active";
        return new SubscriptionResource(entity.Id, entity.SubscriptionStartDate, entity.SubscriptionEndDate, isActive, entity.SubscriptionType);
    }
}