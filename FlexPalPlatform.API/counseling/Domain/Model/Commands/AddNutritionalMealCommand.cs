namespace FlexPalPlatform.API.Counseling.Domain.Model.Commands;

public record AddNutritionalMealCommand(int FitnessPlanId, string Name, int Weight);