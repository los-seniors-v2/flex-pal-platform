namespace FlexPalPlatform.API.iam.Interfaces.REST.Resources;

public record CreateUserResource(string UserName, string Password, string Role);