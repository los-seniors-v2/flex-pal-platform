namespace FlexPalPlatform.API.Subscriptions.Interfaces.REST.Resources;

public record CreateSubscriptionResource(DateTime StartDate, DateTime EndDate, bool IsActive, string Type);