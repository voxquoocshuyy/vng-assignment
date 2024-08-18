using Application.Common.Interfaces;
using Application.Common.Models.Users;
using Application.Common.Results;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUsersCommandHandler : IRequestHandler<CreateUsersCommand, ApiResult<IEnumerable<UserDto>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUsersCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ApiResult<IEnumerable<UserDto>>> Handle(CreateUsersCommand request,
        CancellationToken cancellationToken)
    {
        var userEntities = _mapper.Map<List<User>>(request.Users);
        userEntities.ForEach(user => user.Status = (int)UserStatusEnum.ACTIVE);
        await _userRepository.CreateListAsync(userEntities);
        await _userRepository.SaveChangesAsync();
        var userDtos = _mapper.Map<IEnumerable<UserDto>>(userEntities);
        return new ApiSuccessResult<IEnumerable<UserDto>>(userDtos);
    }
}