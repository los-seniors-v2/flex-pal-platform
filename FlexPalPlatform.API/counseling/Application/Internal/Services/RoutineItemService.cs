using FlexPalPlatform.API.Counseling.Domain.Model.Entities;
using FlexPalPlatform.API.Counseling.Domain.Repositories;
using FlexPalPlatform.API.Counseling.Domain.Services;

namespace FlexPalPlatform.API.counseling.Application.Internal.Services;

public class RoutineItemService(IRoutineItemRepository routineItemRepository) : IRoutineItemService
{
    public async Task<RoutineItem?> GetByIdAsync(int id)
    {
        return await routineItemRepository.FindByIdAsync(id);
    }

    public async Task<IEnumerable<RoutineItem>> GetAllAsync()
    {
        return await routineItemRepository.GetAllAsync();
    }

    public async Task AddAsync(RoutineItem routineItem)
    {
        await routineItemRepository.AddAsync(routineItem);
    }

    public async Task UpdateAsync(RoutineItem routineItem)
    {
        await routineItemRepository.UpdateAsync(routineItem);
    }

    public async Task DeleteAsync(int id)
    {
        await routineItemRepository.DeleteAsync(id);
    }
}