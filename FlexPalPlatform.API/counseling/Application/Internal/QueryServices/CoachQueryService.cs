using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.counseling.Domain.Model.Queries;
using FlexPalPlatform.API.Counseling.Domain.Model.Queries;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Counseling.Domain.Services;

namespace FlexPalPlatform.API.counseling.Application.Internal.QueryServices;

public class CoachQueryService(ICoachRepository coachRepository) : ICoachQueryService
{
    public async Task<IEnumerable<Coach>> Handle(GetAllCoachesQuery query) => await coachRepository.ListAsync();

    public async Task<Coach?> Handle(GetCoachByIdQuery query) => await coachRepository.FindByIdAsync(query.CoachId);
}