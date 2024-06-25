using System.Text.Json.Serialization;
using FlexPalPlatform.API.Counseling.Domain.Model.Aggregates;
using FlexPalPlatform.API.Counseling.Domain.Model.Commands;

namespace FlexPalPlatform.API.Counseling.Domain.Model.Entities;

public class RoutineItem
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Sets { get; private set; }
    public int Reps { get; private set; }
    public string Type { get; private set; }
    public int RestTime { get; private set; }
    public int FitnessPlanId { get; set; } // FK to FitnessPlan
    
    [JsonIgnore]
    public FitnessPlan FitnessPlan { get; set; } // Navigation Property
    
    public RoutineItem(string name, int sets, int reps, string type, int restTime)
    {
        Name = name;
        Sets = sets;
        Reps = reps;
        Type = type;
        RestTime = restTime;
    }

    public RoutineItem(CreateRoutineItemCommand command)
    {
        Name = command.Name;
        Sets = command.Sets;
        Reps = command.Reps;
        Type = command.Type;
        RestTime = command.RestTime;
    }
}