using Application.Common.Models;
using Application.Common.Results;
using MediatR;

namespace Application.Features.Books.Queries.GetBooks;

public class GetBooksQuery : IRequest<ApiResult<List<BookDto>>>
{
}