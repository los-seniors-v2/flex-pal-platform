using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public class CreateDailyExerciseResourceFromEntityAssembler
{
    public static CreateDailyExerciseCommand ToCommandFromEntity(CreateDailyExerciseResource resource)
    {
        return new CreateDailyExerciseCommand(resource.Name, resource.State);
    }
}