using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public static class AddRoutineItemToFitnessPlanCommandFromResourceAssembler
{
    public static AddRoutineItemToFitnessPlanCommand ToCommandFromResource(AddRoutineItemToFitnessPlanResource resource, int tutorialId)
    {
        return new AddRoutineItemToFitnessPlanCommand(resource.Name, resource.Sets, resource.Reps, resource.Type, resource.RestTime, tutorialId);
    }
}