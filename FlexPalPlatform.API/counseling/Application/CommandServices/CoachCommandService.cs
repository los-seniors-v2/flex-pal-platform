using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Domain.Services;
using FlexPalPlatform.API.Counseling.Domain.Repositories;

namespace FlexPalPlatform.API.Counseling.Application.CommandServices;

public class CoachCommandService : ICoachService
{
    private readonly ICoachRepository _coachRepository;

    public CoachCommandService(ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    public async Task<Coach> CreateCoachAsync(CreateCoachCommand command)
    {
        var coach = new Coach(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Phone,
            command.Knowledge
        );
        
        await _coachRepository.AddAsync(coach);
        return coach;
    }

    public async Task<Coach?> GetCoachByIdAsync(int coachId)
    {
        return await _coachRepository.FindByIdAsync(coachId);
    }
}