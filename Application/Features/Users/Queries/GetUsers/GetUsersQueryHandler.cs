using Application.Common.Interfaces;
using Application.Common.Results;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ApiResult<List<User>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResult<List<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var usersEntities = await _userRepository.GetUserToUpdatePasswordAsync();
        var userList = _mapper.Map<List<User>>(usersEntities);
        return new ApiSuccessResult<List<User>>(userList);
    }
}