using FlexPalPlatform.API.Profiles.Interfaces.ACL.Services;

namespace FlexPalPlatform.API.iam.Application.Internal.OutboundServices.ACL;

public class ExternalProfileService(IProfilesContextFacade profilesContextFacade) : IExternalProfileService
{
    /**
     *  public async Task<ProfileId?> CreateProfile(string firstName, string lastName, string email, string street,
        string number, string city, string postalCode, string country)
    {
        var profileId = await profilesContextFacade.CreateProfile(firstName, lastName, email, street, number, city,
            postalCode, country);
        if (profileId == 0) return await Task.FromResult<ProfileId?>(null);
        return new ProfileId(profileId);
    }
     */
    public async Task<int> CreateProfileAsync(string firstName, string lastName, string email, string weight, string height, string phone, string role)
    {
        return await profilesContextFacade.CreateProfile(firstName, lastName, email, weight, height, phone, role);
    }
}
