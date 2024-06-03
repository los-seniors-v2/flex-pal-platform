namespace FlexPalPlatform.API.Subscriptions.Domain.Model.ValueObjects;

public record MemberStatus(bool IsActive, string Type)
{
    public MemberStatus() : this(false, string.Empty)
    {
    }
    
}