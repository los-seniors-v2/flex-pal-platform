namespace FlexPalPlatform.API.Counseling.Domain.Model.Commands;

public record AddDailyExerciseCommand(int FitnessPlanId, string Name, string State);