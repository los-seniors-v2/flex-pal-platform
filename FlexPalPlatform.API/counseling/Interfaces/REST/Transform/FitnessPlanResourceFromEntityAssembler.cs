using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public class FitnessPlanResourceFromEntityAssembler
{
    public static FitnessPlanResource ToResourceFromEntity(FitnessPlan fitnessPlan)
    {
        return new FitnessPlanResource(fitnessPlan.Id, fitnessPlan.ProfileId, fitnessPlan.CoachId, fitnessPlan.RoutineItems, fitnessPlan.NutritionalMeals, fitnessPlan.DailyExercises);
    }
}