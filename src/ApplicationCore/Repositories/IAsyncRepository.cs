using ApplicationCore.Filters;

namespace ApplicationCore.Repositories
{
    public interface IAsyncRepository<T, F>
    {
        Task<List<T>> GetAsync(Dictionary<string, string> filter, BaseFilter<T> spec, CancellationToken cancellation);
        Task<bool> CreateAsync(T entity, CancellationToken cancellation);
        Task<bool> EditAsync(T entity, int id, CancellationToken cancellation);
        Task<bool> DeleteAsync(int id, CancellationToken cancellation);
    }
}
