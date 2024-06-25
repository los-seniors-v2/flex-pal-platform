using FlexPalPlatform.API.Profiles.Domain.Model.Aggregates;
using FlexPalPlatform.API.Profiles.Domain.Repositories;
using FlexPalPlatform.API.Profiles.Domain.Services;
using FlexPalPlatform.API.Profiles.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Profiles.Application.Internal.CommandServices;

public class WeightLossCommandService : IWeightLossService
{
    private readonly IProfileRepository _profileRepository;

    public WeightLossCommandService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<WeightLossProjectionResource> CalculateWeightLossAsync(int profileId)
    {
        var profile = await _profileRepository.FindByIdAsync(profileId);
        if (profile == null)
            throw new Exception("Perfil no encontrado");

        return new WeightLossProjectionResource
        {
            WeightLossInOneMonth = CalculateWeightLossForPeriod(profile, 1),
            WeightLossInTwoMonths = CalculateWeightLossForPeriod(profile, 2),
            WeightLossInThreeMonths = CalculateWeightLossForPeriod(profile, 3)
        };
    }

    private double CalculateWeightLossForPeriod(Profile profile, int months)
    {
        
        return 1.5 * months;
    }
}
