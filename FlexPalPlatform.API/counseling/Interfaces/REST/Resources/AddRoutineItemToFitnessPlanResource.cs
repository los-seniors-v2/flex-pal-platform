namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

public record AddRoutineItemToFitnessPlanResource(string Name, int Sets, int Reps, string Type, int RestTime);