using api.Models.Abstract;

namespace api.Services
{
    public interface IService<T> where T : Entity
    {
        Task<IEnumerable<T>> GetManyAsync(bool isTrackingEnabled = true);
        Task<T?> GetAsync(int id, bool isTrackingEnabled = true);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
