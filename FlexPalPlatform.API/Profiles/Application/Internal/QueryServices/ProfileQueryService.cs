using FlexPalPlatform.API.Profiles.Domain.Model.Aggregates;
using FlexPalPlatform.API.Profiles.Domain.Model.Queries;
using FlexPalPlatform.API.Profiles.Domain.Repositories;
using FlexPalPlatform.API.Profiles.Domain.Services;

namespace FlexPalPlatform.API.Profiles.Application.Internal.QueryServices;

public class ProfileQueryService(IProfileRepository profileRepository): IProfileQueryService
{
    public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }

    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
         return await profileRepository.FindByIdAsync(query.ProfileId);
    }
}