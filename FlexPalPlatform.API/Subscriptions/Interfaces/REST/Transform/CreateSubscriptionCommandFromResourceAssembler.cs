using FlexPalPlatform.API.Subscriptions.Domain.Model.Commands;
using FlexPalPlatform.API.Subscriptions.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Subscriptions.Interfaces.REST.Transform;

public static class CreateSubscriptionCommandFromResourceAssembler
{
    public static CreateSubscriptionCommand ToCommandFromResource(CreateSubscriptionResource resource)
    {
        return new CreateSubscriptionCommand(resource.StartDate, resource.EndDate, resource.IsActive, resource.Type);
    }
}