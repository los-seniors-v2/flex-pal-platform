namespace FlexPalPlatform.API.Profiles.Domain.Model.ValueObjects;

public record RoleType(string Role)
{
    public RoleType() : this(string.Empty)
    {
    }
    
}