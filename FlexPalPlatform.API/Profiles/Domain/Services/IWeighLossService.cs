using FlexPalPlatform.API.Profiles.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Profiles.Domain.Services;

public interface IWeightLossService
{
    Task<WeightLossProjectionResource> CalculateWeightLossAsync(int profileId);
}