using FlexPalPlatform.API.Profiles.Domain.Model.Aggregates;
using FlexPalPlatform.API.Profiles.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Profiles.Interfaces.REST.Transform;

/// <summary>
/// Assembler for transforming Profile entity to ProfileResource.
/// </summary>
public static class ProfileResourceFromEntityAssembler
{
    /// <summary>
    /// Transforms a Profile entity to a ProfileResource.
    /// </summary>
    /// <param name="entity">The entity to transform.</param>
    /// <returns>The created resource.</returns>
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

        return new ProfileResource(
            entity.Id,
            entity.FullName,
            entity.EmailAddress,
            entity.Weight,
            entity.Height,
            entity.PhoneNumber,
            entity.RoleType
        );
    }
}