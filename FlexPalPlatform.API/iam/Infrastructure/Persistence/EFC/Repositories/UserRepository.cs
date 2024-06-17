using FlexPalPlatform.API.iam.Domain.Model.Aggregates;
using FlexPalPlatform.API.iam.Domain.Repositories;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlexPalPlatform.API.iam.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context): BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await context.Set<User>().FirstOrDefaultAsync(user => user.Username == username);
    }
    public async Task<User?> FindByRoleAsync(string role)
    {
        return await context.Set<User>().FirstOrDefaultAsync(user => user.Role == role);
    }
    public bool ExistsByUsername(string username)
    {
        return context.Set<User>().Any(user => user.Username == username);
    }
}


