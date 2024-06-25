using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Queries;

namespace FlexPalPlatform.API.Counseling.Domain.Services;

public interface IFitnessPlanQueryService
{
    Task<IEnumerable<FitnessPlan>> Handle(GetAllFitnessPlansQuery query);
    Task<FitnessPlan?> Handle(GetFitnessPlanByIdQuery query);
}