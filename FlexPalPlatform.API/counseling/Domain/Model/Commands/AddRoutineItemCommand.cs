namespace FlexPalPlatform.API.Counseling.Domain.Model.Commands;

public record AddRoutineItemCommand(int FitnessPlanId, string Name, int Sets, int Reps, string Type, int RestTime);