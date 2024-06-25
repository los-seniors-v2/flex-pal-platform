using System.Text.Json.Serialization;
using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;

namespace FlexPalPlatform.API.Counseling.Domain.Model.Entities;

public class DailyExercise
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string State { get; private set; }
    public int FitnessPlanId { get; set; } // FK to FitnessPlan
    
    [JsonIgnore]
    public FitnessPlan FitnessPlan { get; set; } // Navigation Property
    
    public DailyExercise(string name, string state)
    {
        Name = name;
        State = state;
    }

    public DailyExercise(CreateDailyExerciseCommand command)
    {
        Name = command.Name;
        State = command.State;
    }
}