using FlexPalPlatform.API.Counseling.Domain.Model.Entities;

namespace FlexPalPlatform.API.Counseling.Domain.Services;

public interface IDailyExerciseService
{
    Task<DailyExercise?> GetByIdAsync(int id);
    Task<IEnumerable<DailyExercise>> GetAllAsync();
    Task AddAsync(DailyExercise dailyExercise);
    Task UpdateAsync(DailyExercise dailyExercise);
    Task DeleteAsync(int id);
    
    
}