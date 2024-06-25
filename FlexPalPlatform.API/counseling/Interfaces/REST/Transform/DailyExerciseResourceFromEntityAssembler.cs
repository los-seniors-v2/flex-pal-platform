using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public class DailyExerciseResourceFromEntityAssembler
{
    public static DailyExerciseResource ToResourceFromEntity(DailyExercise entity)
    {
        return new DailyExerciseResource(entity.Id, entity.Name, entity.State, entity.FitnessPlanId);
    }
}