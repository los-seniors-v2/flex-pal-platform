namespace FlexPalPlatform.API.Counseling.Domain.Model.Commands;

public record AddNutritionalMealToFitnessPlanCommand(string Name, int Weight, int FitnessPlanId);