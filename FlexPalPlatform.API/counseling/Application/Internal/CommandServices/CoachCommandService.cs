using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Counseling.Domain.Services;
using FlexPalPlatform.API.Shared.Domain.Repositories;

namespace FlexPalPlatform.API.counseling.Application.Internal.CommandServices;

public class CoachCommandService(ICoachRepository coachRepository, IUnitOfWork unitOfWork) : ICoachCommandService
{
    public async Task<Coach?> Handle(CreateCoachCommand command)
    {
        var coach = new Coach(command);
        try
        {
            await coachRepository.AddAsync(coach);
            await unitOfWork.CompleteAsync();
            return coach;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating a Coach: {e.Message}");
            return null;
        }
    }
}