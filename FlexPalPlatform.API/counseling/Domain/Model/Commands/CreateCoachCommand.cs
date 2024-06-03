namespace FlexPalPlatform.API.Counseling.Domain.Model.Commands;

public record CreateCoachCommand(string FirstName, string LastName, string Email, string Phone, string Knowledge);