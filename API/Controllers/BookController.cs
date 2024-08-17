using Application.Common.Models;
using Application.Common.Results;
using Application.Features.Books.Commands.CreateBook;
using Application.Features.Books.Commands.UpdateBook;
using Application.Features.Books.Queries.GetBook;
using Application.Features.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(ApiResult<IEnumerable<BookDto>>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
    {
        var query = new GetBooksQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResult<BookDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks(int id)
    {
        var query = new GetBookByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ApiResult<IEnumerable<int>>), StatusCodes.Status201Created)]
    public async Task<ActionResult<IEnumerable<int>>> CreateBook([FromBody] CreateBookCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResult<BookDto>), StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateBook(int id, [FromBody] UpdateBookCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}