using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Results;
using AutoMapper;
using MediatR;

namespace Application.Features.Books.Queries.GetBook;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, ApiResult<BookDto>>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ApiResult<BookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var booksEntities = await _bookRepository.GetByIdAsync(request.Id);
        var bookList = _mapper.Map<BookDto>(booksEntities);
        return new ApiSuccessResult<BookDto>(bookList);
    }
}