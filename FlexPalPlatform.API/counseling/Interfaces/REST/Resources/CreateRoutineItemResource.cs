namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

public record CreateRoutineItemResource(string Name, int Sets, int Reps, string Type, int RestTime);