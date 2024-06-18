using FlexPalPlatform.API.Subscriptions.Domain.Model.Aggregates;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Commands;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Repositories;
using FlexPalPlatform.API.Shared.Domain.Repositories;
using FlexPalPlatform.API.Subscriptions.Domain.Model.Services;

namespace FlexPalPlatform.API.Subscriptions.Application.Internal.CommandServices;

public class SubscriptionCommandService (ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork) : ISubscriptionCommandService

{
    public async Task<Subscription?> Handle(CreateSubscriptionCommand command)
    {
        var subscription = new Subscription(command);
        try
        {
            await subscriptionRepository.AddAsync(subscription);
            await unitOfWork.CompleteAsync();
            return subscription;
        } 
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the subscription: {e.Message}");
            return null;
        }
    }
}