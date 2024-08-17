using Application.Common.Models;
using Application.Common.Results;
using MediatR;

namespace Application.Features.Books.Commands.UpdateBook;

public class UpdateBookCommand : IRequest<ApiResult<BookDto>>
{
    public int Id { get; set; }
    public void SetId(int id)
    {
        Id = id;
    }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublishedYear { get; set; }
}