namespace FlexPalPlatform.API.Profiles.Domain.Model.ValueObjects;
/// <summary>
/// Value object representing a phone number.
/// </summary>
public record PhoneNumber(string Number)
{
    public PhoneNumber() : this(string.Empty)
    {
    }
}