using System.ComponentModel.DataAnnotations;
using Application.Common.Models;
using Application.Common.Results;
using Application.Features.Books.Commands.CreateBook;
using Application.Features.Books.Commands.DeleteBook;
using Application.Features.Books.Commands.UpdateBook;
using Application.Features.Books.Queries.GetBook;
using Application.Features.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    [SwaggerOperation(Summary = "Get all books")]
    [ProducesResponseType(typeof(ApiResult<IEnumerable<BookDto>>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
    {
        var query = new GetBooksQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get book by id")]
    [ProducesResponseType(typeof(ApiResult<BookDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks(int id)
    {
        var query = new GetBookByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new book")]
    [ProducesResponseType(typeof(ApiResult<IEnumerable<BookDto>>), StatusCodes.Status201Created)]
    public async Task<ActionResult<IEnumerable<BookDto>>> CreateBook([FromBody] CreateBookCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Update a book")]
    [ProducesResponseType(typeof(ApiResult<BookDto>), StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateBook([Required] int id, [FromBody] UpdateBookCommand command)
    {
        command.SetId(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a book")]
    [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteBook([Required] int id)
    {
        var command = new DeleteBookCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}