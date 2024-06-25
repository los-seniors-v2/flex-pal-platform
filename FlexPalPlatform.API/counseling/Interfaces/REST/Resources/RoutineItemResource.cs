namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

public record RoutineItemResource(int Id, string Name, int Sets, int Reps, string Type, int RestTime, int FitnessPlanId);