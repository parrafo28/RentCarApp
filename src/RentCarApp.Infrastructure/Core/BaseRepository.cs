using Microsoft.EntityFrameworkCore;
using RentCarApp.Domain.Core;
using RentCarApp.Persistence;
using System.Linq.Expressions;

namespace RentCarApp.Infrastructure.Core
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext Context;

        public BaseRepository(DataContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetEntityById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
        public async Task<int> Add(T entity)
        {
            Context.Set<T>().Add(entity);
            return entity.Id;
        }
        public async Task Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
