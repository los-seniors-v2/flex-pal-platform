using FlexPalPlatform.API.Counseling.Domain.Model.Commands;
using FlexPalPlatform.API.Counseling.Interfaces.REST.Resources;

namespace FlexPalPlatform.API.Counseling.Interfaces.REST.Transform;

public class AddNutritionalMealCommandFromResourceAssembler
{
    public static AddNutritionalMealToFitnessPlanCommand ToCommandFromResource(AddNutritionMealToFitnessPlanResource resource, int tutorialId)
    {
        return new AddNutritionalMealToFitnessPlanCommand(resource.Name, resource.Weight, tutorialId);
    }
}