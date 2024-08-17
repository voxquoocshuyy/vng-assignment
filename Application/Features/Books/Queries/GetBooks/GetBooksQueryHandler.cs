using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Results;
using AutoMapper;
using MediatR;

namespace Application.Features.Books.Queries.GetBooks;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, ApiResult<List<BookDto>>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResult<List<BookDto>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var booksEntities = _bookRepository.FindAll();
        var bookList = _mapper.Map<List<BookDto>>(booksEntities);
        return new ApiSuccessResult<List<BookDto>>(bookList);
    }
}