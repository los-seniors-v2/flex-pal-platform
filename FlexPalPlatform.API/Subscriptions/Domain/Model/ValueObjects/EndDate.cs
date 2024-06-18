namespace FlexPalPlatform.API.Subscriptions.Domain.Model.ValueObjects;

public record EndDate(DateTime Value)
{
    public EndDate() : this(DateTime.MinValue)
    {
    }
}