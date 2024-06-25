using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public class NutritionalMealResourceFromEntityAssembler
{
    public static NutritionalMealResource ToResourceFromEntity(NutritionalMeal entity)
    {
        return new NutritionalMealResource(entity.Id, entity.Name, entity.Weight, entity.FitnessPlanId);
    }
}