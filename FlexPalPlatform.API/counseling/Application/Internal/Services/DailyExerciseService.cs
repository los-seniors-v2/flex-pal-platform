using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Counseling.Domain.Services;
using FlexPalPlatform.API.Counseling.Infrastructure.Persistence.EFC.Repositories;

namespace FlexPalPlatform.API.counseling.Application.Internal.Services;

public class DailyExerciseService (IDailyExerciseRepository dailyExerciseRepository) : IDailyExerciseService
{
    public async Task<DailyExercise?> GetByIdAsync(int id)
    {
        return await dailyExerciseRepository.FindByIdAsync(id);
    }
    
    public async Task<IEnumerable<DailyExercise>> GetAllAsync()
    {
        return await dailyExerciseRepository.GetAllAsync();
    }
    
    public async Task AddAsync(DailyExercise dailyExercise)
    {
        await dailyExerciseRepository.AddAsync(dailyExercise);
    }
    
    public async Task UpdateAsync(DailyExercise dailyExercise)
    {
        await dailyExerciseRepository.UpdateAsync(dailyExercise);
    }
    
    public async Task DeleteAsync(int id)
    {
        await dailyExerciseRepository.DeleteAsync(id);
    }
}