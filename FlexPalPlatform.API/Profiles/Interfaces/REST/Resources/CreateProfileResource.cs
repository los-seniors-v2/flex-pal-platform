namespace FlexPalPlatform.API.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string FirstName, string LastName, string Email, string Phone, string Role);