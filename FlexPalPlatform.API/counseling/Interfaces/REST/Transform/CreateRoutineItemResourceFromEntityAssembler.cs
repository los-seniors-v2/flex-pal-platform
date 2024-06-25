using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public class CreateRoutineItemResourceFromEntityAssembler
{
    public static CreateRoutineItemCommand ToResourceFromEntity(CreateRoutineItemResource resource)
    {
        return new CreateRoutineItemCommand(resource.Name, resource.Sets, resource.Reps, resource.Type, resource.RestTime);
    }
}