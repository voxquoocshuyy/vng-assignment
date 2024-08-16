using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
{
    Task<int> CommitAsync();
}