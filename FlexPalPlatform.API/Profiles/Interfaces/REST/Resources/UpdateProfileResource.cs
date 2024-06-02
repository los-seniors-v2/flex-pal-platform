namespace FlexPalPlatform.API.Profiles.Interfaces.REST.Resources;
/// <summary>
/// Resource for updating a profile.
/// </summary>
public record UpdateProfileResource(int Id,string Email,string Weight,string Height, string Phone);