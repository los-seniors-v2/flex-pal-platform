using FlexPalPlatform.API.Counseling.Domain.Model.Entities;

namespace FlexPalPlatform.API.Counseling.Domain.Repositories;

public interface INutritionalMealRepository
{
    Task<NutritionalMeal?> FindByIdAsync(int id);
    Task<IEnumerable<NutritionalMeal>> GetAllAsync();
    Task AddAsync(NutritionalMeal nutritionalMeal);
    Task UpdateAsync(NutritionalMeal nutritionalMeal);
    Task DeleteAsync(int id);
}