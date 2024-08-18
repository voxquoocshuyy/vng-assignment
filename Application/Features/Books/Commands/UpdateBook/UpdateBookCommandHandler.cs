using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Results;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, ApiResult<BookDto>>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
    }

    public async Task<ApiResult<BookDto>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var bookEntity = _mapper.Map<Book>(request);
        await _bookRepository.UpdateAsync(bookEntity);
        await _bookRepository.SaveChangesAsync();
        var updatedBook = await _bookRepository.GetByIdAsync(request.Id);
        var result = _mapper.Map<BookDto>(updatedBook);
        return new ApiSuccessResult<BookDto>(result);
    }
}