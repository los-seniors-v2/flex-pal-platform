using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Domain.Model.Entities;

namespace FlexPalPlatform.API.Counseling.Domain.Services;

public interface IFitnessPlanCommandService
{
    Task<FitnessPlan?> Handle(CreateFitnessPlanCommand command);
    Task<FitnessPlan?> Handle(AddRoutineItemToFitnessPlanCommand command);
    Task<FitnessPlan?> Handle(AddNutritionalMealToFitnessPlanCommand command);
}