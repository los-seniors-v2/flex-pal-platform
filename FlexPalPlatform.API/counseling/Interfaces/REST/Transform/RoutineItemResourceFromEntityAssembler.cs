using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public class RoutineItemResourceFromEntityAssembler
{
    public static RoutineItemResource ToResourceFromEntity(RoutineItem entity)
    {
        return new RoutineItemResource(entity.Id, entity.Name, entity.Sets, entity.Reps, entity.Type, entity.RestTime, entity.FitnessPlanId);
    }
}