using Application.Common.Models;
using Application.Common.Results;
using MediatR;

namespace Application.Features.Books.Commands.CreateBook;

public class CreateBookCommand : IRequest<ApiResult<BookDto>>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublishedYear { get; set; }
}