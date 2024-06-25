using System.Collections.Generic;
using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
namespace FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;

public class FitnessPlan(int profileId, int coachId)
{
    public int Id { get; private set; }
    public int ProfileId { get; private set; } = profileId;
    public int CoachId { get; private set; } = coachId;
    public List<RoutineItem> RoutineItems { get; private set; } = new();
    public List<NutritionalMeal> NutritionalMeals { get; private set; } = new();

    public void AddRoutineItem(RoutineItem routineItem)
    {
        RoutineItems.Add(routineItem);
    }

    public void AddNutritionalMeal(NutritionalMeal nutritionalMeal)
    {
        NutritionalMeals.Add(nutritionalMeal);
    }
}