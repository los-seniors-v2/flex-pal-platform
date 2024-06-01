using FlexPalPlatform.API.iam.Application.Internal.OutboundServices.ACL;
using FlexPalPlatform.API.iam.Domain.Model.Aggregates;
using FlexPalPlatform.API.iam.Domain.Model.Commands;
using FlexPalPlatform.API.iam.Domain.Repositories;
using FlexPalPlatform.API.iam.Domain.Services;
using FlexPalPlatform.API.Shared.Domain.Repositories;

namespace FlexPalPlatform.API.iam.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork,IExternalProfileService externalProfileService): IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command, string firstName, string lastName, string email,
        string weight, string height, string phone)
    {
        var user = new User(command);
        try
        {
            // Crear el perfil asociado en el contexto Profile
            var profileId = await externalProfileService.CreateProfileAsync(firstName, lastName, email, weight, height,
                phone, command.Role);

            if (profileId == 0)
            {
                throw new Exception("Failed to create profile.");
            }

            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the User: {e.Message}");
            return null;
        }
    }

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