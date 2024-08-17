using Application.Common.Models;
using Application.Features.Books.Commands.CreateBook;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.BookProfile();
    }

    private void BookProfile()
    {
        this.CreateMap<Book, BookDto>().ReverseMap();
        this.CreateMap<Book, CreateBookCommand>().ReverseMap();
    }
}