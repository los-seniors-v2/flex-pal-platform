
using FlexPalPlatform.API.iam.Application.Internal.OutboundServices;

using FlexPalPlatform.API.iam.Domain.Model.Aggregates;
using FlexPalPlatform.API.iam.Domain.Model.Commands;
using FlexPalPlatform.API.iam.Domain.Repositories;
using FlexPalPlatform.API.iam.Domain.Services;
using FlexPalPlatform.API.Shared.Domain.Repositories;

namespace FlexPalPlatform.API.iam.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, ITokenService tokenService, IHashingService hashingService, IUnitOfWork unitOfWork): IUserCommandService
{
    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} already exists.");
        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        } catch (Exception e)
        {
            throw new Exception("An error occurred while trying to sign up the user.", e);
        }
    }
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);
        if (user is null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password.");
        var token = tokenService.GenerateToken(user);
        return (user, token);
    }
    
    
}