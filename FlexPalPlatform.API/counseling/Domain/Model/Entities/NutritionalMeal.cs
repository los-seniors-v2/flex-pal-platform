using System.Text.Json.Serialization;
using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;

namespace FlexPalPlatform.API.Counseling.Domain.Model.Entities;

public class NutritionalMeal
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Weight { get; private set; }
    public int FitnessPlanId { get; set; } // FK to FitnessPlan
    
    [JsonIgnore]
    public FitnessPlan FitnessPlan { get; set; } // Navigation Property

    public NutritionalMeal(string name, int weight)
    {
        Name = name;
        Weight = weight;
    }
}