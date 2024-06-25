using FlexPalPlatform.API.Counseling.Domain.Model.Entities;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

public record FitnessPlanResource(int Id, int ProfileId, int CoachId, List<RoutineItem> RoutineItems, List<NutritionalMeal> NutritionalMeals);