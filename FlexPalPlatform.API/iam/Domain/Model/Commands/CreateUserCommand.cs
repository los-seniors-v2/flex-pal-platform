namespace FlexPalPlatform.API.iam.Domain.Model.Commands;

public record CreateUserCommand(string Username, string Password, string Role);