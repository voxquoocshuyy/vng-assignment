using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Results;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Books.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ApiResult<BookDto>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<ApiResult<BookDto>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var bookEntity = _mapper.Map<Book>(request);
        await _bookRepository.CreateAsync(bookEntity);
        await _bookRepository.SaveChangesAsync();
        var result = _mapper.Map<BookDto>(bookEntity);
        return new ApiSuccessResult<BookDto>(result);
    }
}