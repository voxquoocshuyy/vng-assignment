using Application.Common.Results;
using MediatR;

namespace Application.Features.Books.Commands.CreateBook;

public class CreateBookCommand : IRequest<ApiResult<int>>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublishedYear { get; set; }
}