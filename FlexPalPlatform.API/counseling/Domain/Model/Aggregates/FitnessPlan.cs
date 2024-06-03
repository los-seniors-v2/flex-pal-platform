using System.Collections.Generic;
using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
namespace FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;

public class FitnessPlan
{
    public int Id { get; private set; }
    public int ProfileId { get; private set; }
    public int CoachId { get; private set; }
    public List<RoutineItem> RoutineItems { get; private set; }
    public List<NutritionalMeal> NutritionalMeals { get; private set; }

    public FitnessPlan(int profileId, int coachId)
    {
        ProfileId = profileId;
        CoachId = coachId;
        RoutineItems = new List<RoutineItem>();
        NutritionalMeals = new List<NutritionalMeal>();
    }

    public void AddRoutineItem(RoutineItem routineItem)
    {
        RoutineItems.Add(routineItem);
    }

    public void AddNutritionalMeal(NutritionalMeal nutritionalMeal)
    {
        NutritionalMeals.Add(nutritionalMeal);
    }
}