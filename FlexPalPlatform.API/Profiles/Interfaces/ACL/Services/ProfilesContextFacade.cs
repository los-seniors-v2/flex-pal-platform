using FlexPalPlatform.API.Profiles.Domain.Model.Commands;
using FlexPalPlatform.API.Profiles.Domain.Services;

namespace FlexPalPlatform.API.Profiles.Interfaces.ACL.Services.Services;

public class ProfilesContextFacade(IProfileCommandService profileCommandService,IProfileQueryService profileQueryService):IProfilesContextFacade
{
    public async Task<int> CreateProfile(string firstName, string lastName, string email, string weight, string height, string phone,
        string role)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, lastName, email, weight, height, phone, role);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }
}