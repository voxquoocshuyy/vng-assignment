using Application.Common.Interfaces;
using Application.Common.Results;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUsersCommandHandler : IRequestHandler<CreateUserCommand, ApiResult<int>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUsersCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<ApiResult<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = _mapper.Map<User>(request);
        var createdUserId = await _userRepository.CreateAsync(userEntity);
        await _userRepository.SaveChangesAsync();
        return new ApiSuccessResult<int>(createdUserId);
    }
}