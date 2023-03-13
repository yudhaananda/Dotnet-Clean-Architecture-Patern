using ApplicationCore.Filters;
using ApplicationCore.Models;

namespace ApplicationCore.Services
{
    public interface IUserRoleService : IAsyncService<UserRole, UserRoleFilter>
    {
        Task<List<UserRole>> GetAsync(Dictionary<string, string> filter, CancellationToken cancellation);
        Task<bool> CreateAsync(UserRole entity, CancellationToken cancellation);
        Task<bool> EditAsync(UserRole entity, int id, CancellationToken cancellation);
        Task<bool> DeleteAsync(int id, CancellationToken cancellation);
    }
}
