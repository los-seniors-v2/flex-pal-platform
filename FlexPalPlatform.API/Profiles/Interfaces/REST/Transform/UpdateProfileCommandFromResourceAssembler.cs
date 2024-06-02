using FlexPalPlatform.API.Profiles.Domain.Model.Commands;
using FlexPalPlatform.API.Profiles.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Profiles.Interfaces.REST.Transform;

/// <summary>
/// Assembler for transforming UpdateProfileResource to UpdateProfileCommand.
/// </summary>
public static class UpdateProfileCommandFromResourceAssembler
{
    /// <summary>
    /// Transforms an UpdateProfileResource to an UpdateProfileCommand.
    /// </summary>
    /// <param name="resource">The resource to transform.</param>
    /// <returns>The created command.</returns>
    public static UpdateProfileCommand ToCommandFromResource(UpdateProfileResource resource)
    {
        if (resource == null)
            throw new ArgumentNullException(nameof(resource), "Resource cannot be null");

        return new UpdateProfileCommand(
            resource.Id,
            resource.Email,
            resource.Weight,
            resource.Height,
            resource.Phone
        );
    }
}