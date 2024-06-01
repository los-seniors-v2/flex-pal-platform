namespace FlexPalPlatform.API.iam.Interfaces.REST.Resources;

public record RegisterUserResource(string UserName, string Password, string Role,
    string FirstName, string LastName, string Email,string Weight,string Height,string Phone);