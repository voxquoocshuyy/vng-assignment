using Application.Common.Models;
using Application.Common.Results;
using MediatR;

namespace Application.Features.Books.Queries.GetBook;

public class GetBookByIdQuery : IRequest<ApiResult<BookDto>>
{
    public int Id { get; private set; }
    public GetBookByIdQuery(int id)
    {
        Id = id;
    }
}