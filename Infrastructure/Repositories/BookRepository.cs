using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class BookRepository : RepositoryBaseAsync<Book, int, AssignmentContext>, IBookRepository
{
    public BookRepository(AssignmentContext dbContext, IUnitOfWork<AssignmentContext> unitOfWork) : base(dbContext, unitOfWork)
    {
    }
}