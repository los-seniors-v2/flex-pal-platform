using FlexPalPlatform.API.Counseling.Domain.Model.Entities;

namespace FlexPalPlatform.API.Counseling.Domain.Services;

public interface INutritionalMealService
{
    Task<NutritionalMeal?> GetByIdAsync(int id);
    Task<IEnumerable<NutritionalMeal>> GetAllAsync();
    Task AddAsync(NutritionalMeal nutritionalMeal);
    Task UpdateAsync(NutritionalMeal nutritionalMeal);
    Task DeleteAsync(int id);
}