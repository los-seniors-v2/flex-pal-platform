using System.Collections;
using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.counseling.Domain.Model.Queries;
using FlexPalPlatform.API.Counseling.Domain.Model.Queries;

namespace FlexPalPlatform.API.Counseling.Domain.Services;

public interface ICoachQueryService
{
    Task<IEnumerable<Coach>> Handle(GetAllCoachesQuery query);
    Task<Coach?> Handle(GetCoachByIdQuery query);
}