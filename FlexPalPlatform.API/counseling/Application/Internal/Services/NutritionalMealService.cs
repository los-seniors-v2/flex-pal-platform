using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Counseling.Domain.Services;

namespace FlexPalPlatform.API.counseling.Application.Internal.Services;

public class NutritionalMealService(INutritionalMealRepository nutritionalMealRepository) : INutritionalMealService
{
    public async Task<NutritionalMeal?> GetByIdAsync(int id)
    {
        return await nutritionalMealRepository.FindByIdAsync(id);
    }

    public async Task<IEnumerable<NutritionalMeal>> GetAllAsync()
    {
        return await nutritionalMealRepository.GetAllAsync();
    }

    public async Task AddAsync(NutritionalMeal nutritionalMeal)
    {
        await nutritionalMealRepository.AddAsync(nutritionalMeal);
    }

    public async Task UpdateAsync(NutritionalMeal nutritionalMeal)
    {
        await nutritionalMealRepository.UpdateAsync(nutritionalMeal);
    }

    public async Task DeleteAsync(int id)
    {
        await nutritionalMealRepository.DeleteAsync(id);
    }
}