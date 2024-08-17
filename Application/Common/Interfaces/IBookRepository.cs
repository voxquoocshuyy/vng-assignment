using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IBookRepository : IRepositoryBaseAsync<Book, int>
{
}