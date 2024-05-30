using FlexPalPlatform.API.Profiles.Domain.Model.Aggregates;
using FlexPalPlatform.API.Profiles.Domain.Model.Commands;

namespace FlexPalPlatform.API.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}