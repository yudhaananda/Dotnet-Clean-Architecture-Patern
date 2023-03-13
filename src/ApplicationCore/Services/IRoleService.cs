using ApplicationCore.Filters;
using ApplicationCore.Models;

namespace ApplicationCore.Services
{
    public interface IRoleService : IAsyncService<Role, RoleFilter>
    {
        Task<List<Role>> GetAsync(Dictionary<string, string> filter, CancellationToken cancellation);
        Task<bool> CreateAsync(Role entity, CancellationToken cancellation);
        Task<bool> EditAsync(Role entity, int id, CancellationToken cancellation);
        Task<bool> DeleteAsync(int id, CancellationToken cancellation);
    }
}
