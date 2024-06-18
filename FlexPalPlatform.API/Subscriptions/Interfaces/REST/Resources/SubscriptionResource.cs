namespace FlexPalPlatform.API.Subscriptions.Interfaces.REST.Resources;

public record SubscriptionResource(int Id, DateTime StartDate, DateTime EndDate, bool IsActive, string Type);