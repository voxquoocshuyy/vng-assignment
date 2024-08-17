using Application.Common.Models;
using Application.Features.Books.Commands.CreateBook;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Queries.GetUsers;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.BookProfile();
        this.UserProfile();
    }

    private void BookProfile()
    {
        this.CreateMap<Book, BookDto>().ReverseMap();
        this.CreateMap<Book, CreateBookCommand>().ReverseMap();
    }
    
    private void UserProfile()
    {
        this.CreateMap<User, GetUsersQuery>()
            .ReverseMap();
        this.CreateMap<User, CreateUserCommand>()
            // for member status
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ReverseMap();
        
    }
}