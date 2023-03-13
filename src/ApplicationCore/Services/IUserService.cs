using ApplicationCore.Filters;
using ApplicationCore.Models;

namespace ApplicationCore.Services
{
    public interface IUserService : IAsyncService<User, UserFilter>
    {
        Task<List<User>> GetAsync(Dictionary<string, string> filter, CancellationToken cancellation);
        Task<bool> CreateAsync(User entity, CancellationToken cancellation);
        Task<bool> EditAsync(User entity, int id, CancellationToken cancellation);
        Task<bool> DeleteAsync(int id, CancellationToken cancellation);
    }
}
