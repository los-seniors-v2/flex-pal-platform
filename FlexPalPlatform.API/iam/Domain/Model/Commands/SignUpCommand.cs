namespace FlexPalPlatform.API.iam.Domain.Model.Commands;

public record SignUpCommand(string Username, string Password, string Role);