using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public class CoachResourceFromEntityAssembler
{
    public static CoachResource ToResourceFromEntity(Coach coach)
    {
        return new CoachResource(coach.Id, coach.FirstName, coach.LastName, coach.Email, coach.Phone, coach.Knowledge);
    }
}