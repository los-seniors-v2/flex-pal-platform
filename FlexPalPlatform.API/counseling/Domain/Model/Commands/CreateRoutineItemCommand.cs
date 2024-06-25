namespace FlexPalPlatform.API.Counseling.Domain.Model.Commands;

public record CreateRoutineItemCommand(string Name, int Sets, int Reps, string Type, int RestTime);