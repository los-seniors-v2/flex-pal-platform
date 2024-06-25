using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public class CreateFitnessPlanResourceFromEntityAssembler
{
    public static CreateFitnessPlanCommand ToCommandFromResource(CreateFitnessPlanResource resource)
    {
        return new CreateFitnessPlanCommand(resource.ProfileId, resource.CoachId);
    }
}