
using Microsoft.EntityFrameworkCore;

namespace AppleAccounts.Data.Base
{
    public class EntityBaseRepo<T>(AppDbContext context) : IEntityBaseRepo<T> where T : class, IEntityBase, new()
    {

        private readonly AppDbContext _context = context;

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(int status, bool expired)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool expired) => await _context.Set<T>().ToListAsync();


        public Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}