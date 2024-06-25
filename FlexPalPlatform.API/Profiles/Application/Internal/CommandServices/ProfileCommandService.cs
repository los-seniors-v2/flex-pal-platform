using FlexPalPlatform.API.Profiles.Domain.Model.Aggregates;
using FlexPalPlatform.API.Profiles.Domain.Model.Commands;
using FlexPalPlatform.API.Profiles.Domain.Repositories;
using FlexPalPlatform.API.Profiles.Domain.Services;
using FlexPalPlatform.API.Shared.Domain.Repositories;

namespace FlexPalPlatform.API.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork):IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }

    public async Task<Profile?> Handle(UpdateProfileCommand command)
    {
        try
        {
            var profile = await profileRepository.FindByIdAsync(command.Id);
            if (profile == null)
            {
                Console.WriteLine($"Profile with id {command.Id} not found.");
                return null;
            }
            profile.Update(command);

            await unitOfWork.CompleteAsync();

            return profile;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the profile: {e.Message}");
            return null;
        }
    }
}