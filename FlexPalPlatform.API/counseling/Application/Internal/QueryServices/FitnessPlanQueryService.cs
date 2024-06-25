using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Queries;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Counseling.Domain.Services;

namespace FlexPalPlatform.API.counseling.Application.Internal.QueryServices;

public class FitnessPlanQueryService(IFitnessPlanRepository fitnessPlanRepository): IFitnessPlanQueryService
{
    public async Task<IEnumerable<FitnessPlan>> Handle(GetAllFitnessPlansQuery query) =>
        await fitnessPlanRepository.ListAsync();

    public async Task<FitnessPlan?> Handle(GetFitnessPlanByIdQuery query) =>
        await fitnessPlanRepository.FindByIdWithRoutineItemsAsync(query.FitnessPlanId);
}