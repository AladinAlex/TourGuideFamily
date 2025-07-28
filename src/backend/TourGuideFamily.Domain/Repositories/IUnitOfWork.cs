using System.Data;

namespace TourGuideFamily.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<IDbTransaction> BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}