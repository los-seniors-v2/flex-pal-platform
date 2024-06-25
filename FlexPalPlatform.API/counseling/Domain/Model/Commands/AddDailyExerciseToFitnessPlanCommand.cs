namespace FlexPalPlatform.API.Counseling.Domain.Model.Commands;

public record AddDailyExerciseToFitnessPlanCommand(string Name, string State, int FitnessPlanId);