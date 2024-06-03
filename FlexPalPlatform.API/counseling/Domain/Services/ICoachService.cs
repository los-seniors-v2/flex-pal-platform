using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;

namespace FlexPalPlatform.API.Counseling.Domain.Services;

public interface ICoachService
{
    Task<Coach> CreateCoachAsync(CreateCoachCommand command);
    Task<Coach?> GetCoachByIdAsync(int coachId);
}
