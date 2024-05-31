using FlexPalPlatform.API.iam.Domain.Model.Aggregates;
using FlexPalPlatform.API.iam.Domain.Model.Commands;

namespace FlexPalPlatform.API.iam.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
}