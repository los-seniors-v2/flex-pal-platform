namespace FlexPalPlatform.API.Counseling.Domain.Model.Commands;

public record AddRoutineItemToFitnessPlanCommand(string Name, int Sets, int Reps, string Type, int RestTime, int FitnessPlanId);