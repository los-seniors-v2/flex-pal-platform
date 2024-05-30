using FlexPalPlatform.API.Profiles.Domain.Model.Aggregates;
using FlexPalPlatform.API.Profiles.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Profiles.Interfaces.REST.Transform;

public interface ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.FullName, entity.EmailAddress,entity.PhoneNumber,entity.RoleType);
    }
}