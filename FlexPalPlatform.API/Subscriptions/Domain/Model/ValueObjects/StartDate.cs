namespace FlexPalPlatform.API.Subscriptions.Domain.Model.ValueObjects;

public record StartDate(DateTime Value)
    {
        public StartDate() : this(DateTime.MinValue)
        {
        }
    }