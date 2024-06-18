namespace FlexPalPlatform.API.Subscriptions.Domain.Model.Commands;

public record CreateSubscriptionCommand(DateTime StartDate, DateTime EndDate, bool IsActive, string Type);