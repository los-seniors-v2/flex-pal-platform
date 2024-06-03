using FlexPalPlatform.API.Subscriptions.Domain.Model.Aggregates;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Commands;

namespace FlexPalPlatform.API.Subscriptions.Domain.Model.Services;

public interface ISubscriptionCommandService
{
    Task<Subscription?> Handle(CreateSubscriptionCommand command);
}