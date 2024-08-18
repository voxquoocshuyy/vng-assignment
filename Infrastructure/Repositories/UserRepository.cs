using Application.Common.Interfaces;
using Application.Common.Models.Users;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : RepositoryBaseAsync<User, int, AssignmentContext>, IUserRepository
{
    private readonly IMapper _mapper;

    public UserRepository(AssignmentContext dbContext, IUnitOfWork<AssignmentContext> unitOfWork, IMapper mapper) :
        base(dbContext,
            unitOfWork)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetUserToUpdatePasswordAsync()
    {
        var sixMonthsAgo = DateTime.Now.AddMonths(-6);

        var listUser = await FindByCondition(u =>
            u.Status != (int)UserStatusEnum.REQUIRE_CHANGE_PWD && u.LastUpdatePassword < sixMonthsAgo).ToListAsync();
        var listUserDto = _mapper.Map<List<UserDto>>(listUser);
        return listUserDto;
    }
}