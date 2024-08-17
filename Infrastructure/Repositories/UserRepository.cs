using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : RepositoryBaseAsync<User, int, AssignmentContext>, IUserRepository
{
    public UserRepository(AssignmentContext dbContext, IUnitOfWork<AssignmentContext> unitOfWork) : base(dbContext,
        unitOfWork)
    {
    }

    public async Task<IEnumerable<User>> GetUserToUpdatePasswordAsync()
    {
        var sixMonthsAgo = DateTime.Now.AddMonths(-6);

        var listUser = await FindByCondition(u =>
            u.Status != (int)UserStatusEnum.REQUIRE_CHANGE_PWD && u.LastUpdatePassword < sixMonthsAgo).ToListAsync();
        return listUser;
    }
}