namespace FlexPalPlatform.API.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string FirstName, string LastName, string Email,string Weight,string Height, string Phone,string Role);