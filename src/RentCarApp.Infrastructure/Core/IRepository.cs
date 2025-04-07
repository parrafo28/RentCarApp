using RentCarApp.Domain.Core;
using System.Linq.Expressions;

namespace RentCarApp.Infrastructure.Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<int> Add(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetEntityById(int id);
        Task Update(T entity);
    }
}