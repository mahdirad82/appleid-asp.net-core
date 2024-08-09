namespace AppleAccounts.Data.Base
{
    public interface IEntityBaseRepo<T> where T : class, IEntityBase, new()
    {

        Task<IEnumerable<T>> GetAllAsync(int status, bool expired);
        Task<IEnumerable<T>> GetAllAsync(bool expired);
        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        Task<T> UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);

    }
}