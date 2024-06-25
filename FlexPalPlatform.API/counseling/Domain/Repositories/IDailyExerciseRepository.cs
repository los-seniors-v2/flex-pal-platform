using FlexPalPlatform.API.Counseling.Domain.Model.Entities;

namespace FlexPalPlatform.API.Counseling.Domain.Repositories;

public interface IDailyExerciseRepository
{
    Task<DailyExercise?> FindByIdAsync(int id);
    Task<IEnumerable<DailyExercise>> GetAllAsync();
    Task AddAsync(DailyExercise dailyExercise);
    Task UpdateAsync(DailyExercise dailyExercise);
    Task DeleteAsync(int id);
    

    
}