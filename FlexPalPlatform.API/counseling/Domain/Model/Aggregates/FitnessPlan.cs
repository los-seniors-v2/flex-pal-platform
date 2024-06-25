using System.Collections.Generic;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
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

    public FitnessPlan(CreateFitnessPlanCommand command)
    {
        ProfileId = command.ProfileId;
        CoachId = command.CoachId;
        RoutineItems = new List<RoutineItem>();
        NutritionalMeals = new List<NutritionalMeal>();
    }
    public void AddRoutineItem(string Name, int Sets, int Reps, string Type, int RestTime)
    {
        RoutineItems.Add(new RoutineItem(Name, Sets, Reps, Type, RestTime));
    } 
    public void AddNutritionalMeal(string Name, int Weight)
    {
        NutritionalMeals.Add(new NutritionalMeal(Name, Weight));
    }
}