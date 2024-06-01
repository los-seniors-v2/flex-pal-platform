using FlexPalPlatform.API.iam.Domain.Model.Aggregates;
using FlexPalPlatform.API.iam.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.iam.Interfaces.REST.Transform;

public interface UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource( entity.Id, entity.Username, entity.Role);
    }
}