using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Counseling.Domain.Services;
using FlexPalPlatform.API.Shared.Domain.Repositories;

namespace FlexPalPlatform.API.counseling.Application.Internal.CommandServices;

public class FitnessPlanCommandService(IFitnessPlanRepository fitnessPlanRepository, IUnitOfWork unitOfWork): IFitnessPlanCommandService
{
    public async Task<FitnessPlan?> Handle(CreateFitnessPlanCommand command)
    {
        var fitnessPlan = new FitnessPlan(command);
        try
        {
            await fitnessPlanRepository.AddAsync(fitnessPlan);
            await unitOfWork.CompleteAsync();
            return fitnessPlan;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<FitnessPlan?> Handle(AddRoutineItemToFitnessPlanCommand command)
    {
        var fitnessPlan = await fitnessPlanRepository.FindByIdAsync(command.FitnessPlanId);
        if (fitnessPlan is null) throw new Exception("Fitness Plan not found");
        fitnessPlan.AddRoutineItem(command.Name, command.Sets, command.Reps, command.Type, command.RestTime);
        try
        {
            await unitOfWork.CompleteAsync();
            return fitnessPlan;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while adding the routine item to the fitness plan: {e.Message}");
            return null;
        }
    }

    public async Task<FitnessPlan?> Handle(AddNutritionalMealToFitnessPlanCommand command)
    {
        var fitnessPlan = await fitnessPlanRepository.FindByIdAsync(command.FitnessPlanId);
        if (fitnessPlan is null) throw new Exception("Fitness Plan not found");
        fitnessPlan.AddNutritionalMeal(command.Name, command.Weight);
        try
        {
            await unitOfWork.CompleteAsync();
            return fitnessPlan;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while adding the nutritional meal to the fitness plan: {e.Message}");
            return null;
        }
    }
}