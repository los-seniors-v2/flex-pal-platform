using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Shared.Domain.Repositories;

namespace FlexPalPlatform.API.Counseling.Domain.Repositories;

public interface IFitnessPlanRepository : IBaseRepository<FitnessPlan>
{
    Task<FitnessPlan?> FindByIdWithRoutineItemsAsync(int id);
}