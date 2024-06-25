using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;

namespace FlexPalPlatform.API.Counseling.Domain.Services;

public interface ICoachCommandService
{
    Task<Coach?> Handle(CreateCoachCommand command);
}