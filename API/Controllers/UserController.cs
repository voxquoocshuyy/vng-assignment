using Application.Common.Models.Users;
using Application.Common.Results;
using Application.Features.Users.Commands.CreateUser;
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
    
    [HttpPost]
    [SwaggerOperation(Summary = "Create list new users")]
    [ProducesResponseType(typeof(ApiResult<IEnumerable<UserDto>>), StatusCodes.Status201Created)]
    public async Task<ActionResult<IEnumerable<UserDto>>> CreateUsers([FromBody] CreateUsersCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
}