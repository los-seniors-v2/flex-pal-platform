using System.ComponentModel.DataAnnotations;

public class AddRoutineItemResource
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Range(1, 100)]
    public int Sets { get; set; }
    
    [Range(1, 100)]
    public int Reps { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Type { get; set; }
    
    [Range(0, 600)]  // Tiempo de descanso en segundos
    public int RestTime { get; set; }
}

public class AddNutritionalMealResource
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Range(1, 10000)]
    public int Weight { get; set; }  // Peso en gramos
}