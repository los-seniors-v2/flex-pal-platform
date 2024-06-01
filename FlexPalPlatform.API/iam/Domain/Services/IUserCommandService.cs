using FlexPalPlatform.API.iam.Domain.Model.Aggregates;
using FlexPalPlatform.API.iam.Domain.Model.Commands;

namespace FlexPalPlatform.API.iam.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
    Task<User?> Handle(CreateUserCommand command, string firstName, string lastName, string email, string weight, string height, string phone);
    Task<string?> Handle(LoginUserCommand command);
}