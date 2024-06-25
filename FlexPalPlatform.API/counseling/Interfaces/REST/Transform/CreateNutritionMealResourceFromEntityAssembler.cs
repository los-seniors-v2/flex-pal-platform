using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public class CreateNutritionMealResourceFromEntityAssembler
{
    public static CreateNutritionItemCommand ToCommandFromEntity(CreateNutritionMealResource resource)
    {
        return new CreateNutritionItemCommand(resource.Name, resource.Weight);
    }
}