using FlexPalPlatform.API.Profiles.Domain.Model.Aggregates;
using FlexPalPlatform.API.Profiles.Domain.Repositories;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace FlexPalPlatform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
/// <summary>
/// Repository implementation for Profile aggregate.
/// </summary>
public class ProfileRepository(AppDbContext context): BaseRepository<Profile>(context),IProfileRepository
{
    
}