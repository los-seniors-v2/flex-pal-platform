using FlexPalPlatform.API.iam.Domain.Model.Aggregates;
using FlexPalPlatform.API.iam.Domain.Model.Queries;

namespace FlexPalPlatform.API.iam.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
}