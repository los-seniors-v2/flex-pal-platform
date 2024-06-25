using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public class AddDailyExerciseCommandFromResourceAssembler
{
    public static AddDailyExerciseToFitnessPlanCommand ToCommandFromResource(AddDailyExerciseToFitnessPlanResource resource, int tutorialId)
    {
        return new AddDailyExerciseToFitnessPlanCommand(resource.Name, resource.State, tutorialId);
    }
}