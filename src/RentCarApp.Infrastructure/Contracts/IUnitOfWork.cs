
namespace RentCarApp.Infrastructure.Core
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task<int> CompleteAsync();
        void Dispose();
        Task RollbackTransactionAsync();
    }
}