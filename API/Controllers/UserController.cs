using Application.Common.Results;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Queries.GetUsers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{ 
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    [HttpGet]
    [SwaggerOperation(Summary = "Get all users")]
    [ProducesResponseType(typeof(ApiResult<IEnumerable<User>>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var result = await _mediator.Send(new GetUsersQuery());
        return Ok(result);
    }
    
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new user")]
    [ProducesResponseType(typeof(ApiResult<IEnumerable<int>>), StatusCodes.Status201Created)]
    public async Task<ActionResult<IEnumerable<int>>> CreateUser([FromBody] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
}