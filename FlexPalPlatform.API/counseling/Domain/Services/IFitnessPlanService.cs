using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Domain.Model.Entities;

namespace FlexPalPlatform.API.Counseling.Domain.Services;

public interface IFitnessPlanService
{
    Task<FitnessPlan> CreateFitnessPlanAsync(CreateFitnessPlanCommand command);
    Task<FitnessPlan?> GetFitnessPlanByIdAsync(int fitnessPlanId);
    Task<bool> AddRoutineItemToFitnessPlanAsync(int fitnessPlanId, RoutineItem item);
    Task<bool> AddNutritionalMealToFitnessPlanAsync(int fitnessPlanId, NutritionalMeal meal);
}