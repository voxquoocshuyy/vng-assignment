using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IUserRepository : IRepositoryBaseAsync<User, int>
{
    Task<IEnumerable<User>> GetUserToUpdatePasswordAsync();
}