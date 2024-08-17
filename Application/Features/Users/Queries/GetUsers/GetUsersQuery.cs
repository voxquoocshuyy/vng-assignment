using Application.Common.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetUsers;

public class GetUsersQuery : IRequest<ApiResult<List<User>>>
{
    
}