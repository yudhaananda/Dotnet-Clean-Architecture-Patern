using ApplicationCore.Filters;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
