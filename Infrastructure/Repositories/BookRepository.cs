using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : RepositoryBaseAsync<Book, int, AssignmentContext>, IBookRepository
{
    public BookRepository(AssignmentContext dbContext, IUnitOfWork<AssignmentContext> unitOfWork) : base(dbContext, unitOfWork)
    {
    }
    
    public async Task<IEnumerable<Book>> GetBooks() =>
        await FindAll().ToListAsync();

    public async Task<Book?> GetBooksById(int id) =>
        await GetByIdAsync(id);
    
    public async Task<int> CreateBook(Book book) =>
        await CreateAsync(book);

    public Task UpdateBook(Book book)
    {
        UpdateAsync(book);
        return Task.CompletedTask;
    }
    
}