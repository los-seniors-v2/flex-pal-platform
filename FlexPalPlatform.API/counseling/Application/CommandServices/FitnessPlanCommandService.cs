using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Shared.Domain.Repositories;
using FlexPalPlatform.API.Counseling.Domain.Services;

namespace FlexPalPlatform.API.Counseling.Application.CommandServices;

public class FitnessPlanCommandService : IFitnessPlanService
{
    private readonly IFitnessPlanRepository _fitnessPlanRepository;
    private readonly IUnitOfWork _unitOfWork;

    public FitnessPlanCommandService(IFitnessPlanRepository fitnessPlanRepository, IUnitOfWork unitOfWork)
    {
        _fitnessPlanRepository = fitnessPlanRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<FitnessPlan> CreateFitnessPlanAsync(CreateFitnessPlanCommand command)
    {
        var fitnessPlan = new FitnessPlan(command.ProfileId, command.CoachId);
        await _fitnessPlanRepository.AddAsync(fitnessPlan);
        await _unitOfWork.CompleteAsync();
        return fitnessPlan;
    }

    public async Task<FitnessPlan?> GetFitnessPlanByIdAsync(int fitnessPlanId)
    {
        return await _fitnessPlanRepository.GetWithDetailsByIdAsync(fitnessPlanId);
    }

    public async Task<bool> AddRoutineItemToFitnessPlanAsync(int fitnessPlanId, RoutineItem item)
    {
        var fitnessPlan = await _fitnessPlanRepository.GetWithDetailsByIdAsync(fitnessPlanId);
        if (fitnessPlan == null) return false;
        
        fitnessPlan.AddRoutineItem(item);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> AddNutritionalMealToFitnessPlanAsync(int fitnessPlanId, NutritionalMeal meal)
    {
        var fitnessPlan = await _fitnessPlanRepository.GetWithDetailsByIdAsync(fitnessPlanId);
        if (fitnessPlan == null) return false;
        
        fitnessPlan.AddNutritionalMeal(meal);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}
