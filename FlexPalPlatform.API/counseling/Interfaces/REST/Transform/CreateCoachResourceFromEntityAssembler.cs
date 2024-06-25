using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public class CreateCoachResourceFromEntityAssembler
{
    public static CreateCoachCommand ToCommandFromResource(CreateCoachResource resource)
    {
        return new CreateCoachCommand(resource.FirstName, resource.LastName, resource.Email, resource.Phone, resource.Knowledge);
    }
}