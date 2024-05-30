using FlexPalPlatform.API.Profiles.Domain.Model.Aggregates;
using FlexPalPlatform.API.Profiles.Domain.Model.Queries;

namespace FlexPalPlatform.API.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
}