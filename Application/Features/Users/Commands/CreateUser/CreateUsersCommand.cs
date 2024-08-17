using System.ComponentModel.DataAnnotations;
using Application.Common.Results;
using Domain.Enums;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand: IRequest<ApiResult<int>>
{
    [EmailAddress]
    public string Email { get; set; }
    public UserStatusEnum Status { get; set; }
    public DateTime LastUpdatePassword { get; set; }
}