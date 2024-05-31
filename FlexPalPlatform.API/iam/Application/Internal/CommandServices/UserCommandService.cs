using FlexPalPlatform.API.iam.Domain.Model.Aggregates;
using FlexPalPlatform.API.iam.Domain.Model.Commands;
using FlexPalPlatform.API.iam.Domain.Repositories;
using FlexPalPlatform.API.iam.Domain.Services;
using FlexPalPlatform.API.Shared.Domain.Repositories;

namespace FlexPalPlatform.API.iam.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork): IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var user = new User(command);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the User: {e.Message}");
            return null;
        }
    }
}