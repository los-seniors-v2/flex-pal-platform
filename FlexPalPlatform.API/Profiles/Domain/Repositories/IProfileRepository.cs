using FlexPalPlatform.API.Profiles.Domain.Model.Aggregates;
using FlexPalPlatform.API.Shared.Domain.Repositories;

namespace FlexPalPlatform.API.Profiles.Domain.Repositories;
/// <summary>
/// Repository interface for Profile aggregate.
/// </summary>
public interface IProfileRepository : IBaseRepository<Profile>
{
    
}