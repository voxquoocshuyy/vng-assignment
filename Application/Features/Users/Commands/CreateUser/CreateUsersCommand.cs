using System.ComponentModel.DataAnnotations;
using Application.Common.Models.Users;
using Application.Common.Results;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUsersCommand : IRequest<ApiResult<IEnumerable<UserDto>>>
{
    public List<CreateUserCommand> Users { get; set; }
}

public class CreateUserCommand: IRequest<ApiResult<List<UserDto>>>
{
    [EmailAddress]
    public string Email { get; set; }
    public DateTime LastUpdatePassword { get; set; }
}